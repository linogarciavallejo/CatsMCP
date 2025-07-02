using CatsMCP.Application.Services;
using CatsMCP.Application.Interfaces.Repositories;
using CatsMCP.Infrastructure.Repositories;
using CatsMCP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;
using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;

// Determine if running as HTTP server or stdio MCP server
var commandArgs = Environment.GetCommandLineArgs();
var runAsHttpServer = commandArgs.Contains("--http") || commandArgs.Contains("--web") || !Console.IsInputRedirected;

if (runAsHttpServer)
{
    // Run as HTTP/WebSocket server for React client
    await RunHttpServer(commandArgs);
}
else
{
    // Run as stdio MCP server for direct testing
    await RunStdioMcpServer(commandArgs);
}

async Task RunStdioMcpServer(string[] args)
{
    var builder = Host.CreateApplicationBuilder(args);

    builder.Logging.AddConsole(consoleLogOptions =>
    {
        // Configure all logs to go to stderr
        consoleLogOptions.LogToStandardErrorThreshold = LogLevel.Trace;
    });

    builder.Services
        .AddDbContext<CatDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

    ConfigureServices(builder.Services, builder.Configuration);

    builder.Services
        .AddMcpServer()
        .WithStdioServerTransport()
        .WithToolsFromAssembly();

    await builder.Build().RunAsync();
}

async Task RunHttpServer(string[] args)
{
    var builder = WebApplication.CreateBuilder(args);

    // Configure services
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "CatsMCP API", Version = "v1" });
    });
    
    // Add CORS for React client
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowReactClient", policy =>
        {
            policy.WithOrigins("http://localhost:3000", "http://localhost:5173", "http://127.0.0.1:3000", "http://127.0.0.1:5173")
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .AllowCredentials();
        });
    });

    builder.Services
        .AddDbContext<CatDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

    ConfigureServices(builder.Services, builder.Configuration);

    var app = builder.Build();

    // Configure pipeline
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseCors("AllowReactClient");
    
    // Add WebSocket support
    app.UseWebSockets(new WebSocketOptions
    {
        KeepAliveInterval = TimeSpan.FromMinutes(2)
    });

    // MCP WebSocket endpoint
    app.Map("/mcp", async (HttpContext context) =>
    {
        if (context.WebSockets.IsWebSocketRequest)
        {
            var webSocket = await context.WebSockets.AcceptWebSocketAsync();
            await HandleMcpWebSocket(webSocket, context.RequestServices);
        }
        else
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
    });

    // HTTP endpoints for direct API access
    app.MapGet("/api/cats", async (IMcpCatService catService) =>
    {
        var cats = await catService.GetCats();
        return Results.Json(cats);
    });

    app.MapGet("/api/cats/{name}", async (string name, IMcpCatService catService) =>
    {
        var cat = await catService.GetCat(name);
        return cat != null ? Results.Json(cat) : Results.NotFound();
    });

    // MCP tools info endpoint
    app.MapGet("/api/mcp/tools", () =>
    {
        return Results.Json(new
        {
            tools = new object[]
            {
                new
                {
                    name = "GetCats",
                    description = "Get a list of cats",
                    inputSchema = new { type = "object", properties = new { } }
                },
                new
                {
                    name = "GetCat",
                    description = "Get a cat by name",
                    inputSchema = new
                    {
                        type = "object",
                        properties = new
                        {
                            name = new { type = "string", description = "The name of the cat to get details for" }
                        },
                        required = new[] { "name" }
                    }
                }
            }
        });
    });

    app.MapControllers();

    await app.RunAsync();
}

async Task HandleMcpWebSocket(System.Net.WebSockets.WebSocket webSocket, IServiceProvider serviceProvider)
{
    var buffer = new byte[1024 * 4];
    
    while (webSocket.State == System.Net.WebSockets.WebSocketState.Open)
    {
        try
        {
            var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            
            if (result.MessageType == System.Net.WebSockets.WebSocketMessageType.Text)
            {
                var message = System.Text.Encoding.UTF8.GetString(buffer, 0, result.Count);
                var response = await ProcessMcpMessage(message, serviceProvider);
                
                if (!string.IsNullOrEmpty(response))
                {
                    var responseBytes = System.Text.Encoding.UTF8.GetBytes(response);
                    await webSocket.SendAsync(
                        new ArraySegment<byte>(responseBytes),
                        System.Net.WebSockets.WebSocketMessageType.Text,
                        true,
                        CancellationToken.None);
                }
            }
            else if (result.MessageType == System.Net.WebSockets.WebSocketMessageType.Close)
            {
                await webSocket.CloseAsync(System.Net.WebSockets.WebSocketCloseStatus.NormalClosure, "", CancellationToken.None);
                break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"WebSocket error: {ex.Message}");
            break;
        }
    }
}

async Task<string> ProcessMcpMessage(string message, IServiceProvider serviceProvider)
{
    try
    {
        using var scope = serviceProvider.CreateScope();
        var catService = scope.ServiceProvider.GetRequiredService<IMcpCatService>();
        
        using var jsonDoc = JsonDocument.Parse(message);
        var root = jsonDoc.RootElement;
        
        if (!root.TryGetProperty("method", out var methodProp))
            return CreateErrorResponse(root, -32601, "Method not found");
            
        var method = methodProp.GetString();
        var id = root.TryGetProperty("id", out var idProp) ? idProp.GetInt32() : 0;
        
        return method switch
        {
            "tools/list" => await HandleToolsList(id),
            "tools/call" => await HandleToolsCall(root, id, catService),
            _ => CreateErrorResponse(root, -32601, "Method not found")
        };
    }
    catch (Exception ex)
    {
        return CreateErrorResponse(JsonDocument.Parse("{}").RootElement, -32603, $"Internal error: {ex.Message}");
    }
}

Task<string> HandleToolsList(int id)
{
    var tools = new object[]
    {
        new
        {
            name = "GetCats",
            description = "Get a list of cats.",
            inputSchema = new { type = "object", properties = new { } }
        },
        new
        {
            name = "GetCat",
            description = "Get a cat by name.",
            inputSchema = new
            {
                type = "object",
                properties = new
                {
                    name = new { type = "string", description = "The name of the cat to get details for" }
                },
                required = new[] { "name" }
            }
        }
    };
    
    return Task.FromResult(JsonSerializer.Serialize(new
    {
        jsonrpc = "2.0",
        id,
        result = new { tools }
    }));
}

async Task<string> HandleToolsCall(JsonElement root, int id, IMcpCatService catService)
{
    if (!root.TryGetProperty("params", out var paramsElement) ||
        !paramsElement.TryGetProperty("name", out var nameElement))
    {
        return CreateErrorResponse(root, -32602, "Invalid params");
    }
    
    var toolName = nameElement.GetString();
    var arguments = paramsElement.TryGetProperty("arguments", out var argsElement) ? argsElement : default;
    
    try
    {
        string result = toolName switch
        {
            "GetCats" => await GetCatsResult(catService),
            "GetCat" => await GetCatResult(catService, arguments),
            _ => throw new InvalidOperationException($"Unknown tool: {toolName}")
        };
        
        return JsonSerializer.Serialize(new
        {
            jsonrpc = "2.0",
            id,
            result = new
            {
                content = new object[]
                {
                    new
                    {
                        type = "text",
                        text = result
                    }
                }
            }
        });
    }
    catch (Exception ex)
    {
        return CreateErrorResponse(root, -32603, $"Tool execution error: {ex.Message}");
    }
}

async Task<string> GetCatsResult(IMcpCatService catService)
{
    var cats = await catService.GetCats();
    return JsonSerializer.Serialize(cats);
}

async Task<string> GetCatResult(IMcpCatService catService, JsonElement arguments)
{
    if (!arguments.TryGetProperty("name", out var nameElement))
        throw new ArgumentException("Missing 'name' argument");
        
    var name = nameElement.GetString() ?? throw new ArgumentException("Invalid 'name' argument");
    var cat = await catService.GetCat(name);
    return JsonSerializer.Serialize(cat);
}

string CreateErrorResponse(JsonElement request, int code, string message)
{
    var id = request.TryGetProperty("id", out var idProp) ? idProp.GetInt32() : 0;
    
    return JsonSerializer.Serialize(new
    {
        jsonrpc = "2.0",
        id,
        error = new
        {
            code,
            message
        }
    });
}

void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    var language = configuration["Language"]?.ToLower() ?? "es";
    if (language == "en")
    {
        services
            .AddScoped<ICatRepositoryEn, CatRepositoryEn>()
            .AddScoped<ICatService<CatEn>, CatServiceEn>()
            .AddScoped<IMcpCatService, McpCatServiceEn>();
    }
    else
    {
        services
            .AddScoped<ICatRepository, CatRepository>()
            .AddScoped<ICatService<Cat>, CatService>()
            .AddScoped<IMcpCatService, McpCatService>();
    }
}
