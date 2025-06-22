using CatsMCP.Application.Services;
using CatsMCP.Application.Interfaces.Repositories;
using CatsMCP.Infrastructure.Repositories;
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
        options.UseSqlServer(builder.Configuration.GetConnectionString("Default")))
    .AddScoped<ICatRepository, CatRepository>()
    .AddScoped<CatService>();

builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly();

await builder.Build().RunAsync();
