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
        options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

var language = builder.Configuration["Language"]?.ToLower() ?? "es";
if (language == "en")
{
    builder.Services
        .AddScoped<ICatRepositoryEn, CatRepositoryEn>()
        .AddScoped<CatServiceEn>()
        .AddScoped<ICatService>(sp => sp.GetRequiredService<CatServiceEn>());
}
else
{
    builder.Services
        .AddScoped<ICatRepository, CatRepository>()
        .AddScoped<CatService>()
        .AddScoped<ICatService>(sp => sp.GetRequiredService<CatService>());
}

builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly();

await builder.Build().RunAsync();
