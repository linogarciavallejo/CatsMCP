using CatsMCP.Application.Services;
using CatsMCP.Application.Interfaces.Repositories;
using CatsMCP.Infrastructure.Repositories;
using CatsMCP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;

var builder = Host.CreateApplicationBuilder(args);

builder.Logging.AddConsole(consoleLogOptions =>
{
    // Configure all logs to go to stderr
    consoleLogOptions.LogToStandardErrorThreshold = LogLevel.Trace;
});

builder.Services
    .AddDbContext<CatDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

var language = builder.Configuration["Language"]?.ToLower() ?? "es";
if (language == "en")
{
    builder.Services
        .AddScoped<ICatRepositoryEn, CatRepositoryEn>()
        .AddScoped<ICatService<CatEn>, CatServiceEn>()
        .AddScoped<IMcpCatService, McpCatServiceEn>();
}
else
{
    builder.Services
        .AddScoped<ICatRepository, CatRepository>()
        .AddScoped<ICatService<Cat>, CatService>()
        .AddScoped<IMcpCatService, McpCatService>();
}

builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly();

await builder.Build().RunAsync();
