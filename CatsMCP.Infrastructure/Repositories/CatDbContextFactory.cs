using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CatsMCP.Infrastructure.Repositories;

/// <summary>
/// Design-time factory for creating CatDbContext instances during migrations.
/// This factory is used by Entity Framework tools to create the DbContext when running commands like:
/// dotnet ef migrations add, dotnet ef database update, etc.
/// </summary>
public class CatDbContextFactory : IDesignTimeDbContextFactory<CatDbContext>
{
    public CatDbContext CreateDbContext(string[] args)
    {
        // Build configuration to read from appsettings.json
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../CatsMCP.WebApi"))
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile("appsettings.Development.json", optional: true)
            .Build();

        // Get connection string from configuration
        var connectionString = configuration.GetConnectionString("Default");
        
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException(
                "Connection string 'Default' not found. " +
                "Please ensure appsettings.json contains a valid connection string.");
        }

        // Configure DbContext options
        var optionsBuilder = new DbContextOptionsBuilder<CatDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new CatDbContext(optionsBuilder.Options);
    }
}
