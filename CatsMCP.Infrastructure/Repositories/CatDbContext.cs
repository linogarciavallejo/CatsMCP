using CatsMCP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Globalization;

namespace CatsMCP.Infrastructure.Repositories;

public class CatDbContext : DbContext
{
    public CatDbContext(DbContextOptions<CatDbContext> options) : base(options)
    {
    }

    public DbSet<Cat> Cats => Set<Cat>();
    public DbSet<CatEn> CatsEn => Set<CatEn>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var converter = new ValueConverter<float[]?, string?>(
            v => v == null ? null : string.Join(',', v.Select(f => f.ToString(CultureInfo.InvariantCulture))),
            v => string.IsNullOrEmpty(v) ? null : ParseFloatArray(v));

        modelBuilder.Entity<Cat>()
            .ToTable("Cats")
            .Property(e => e.EmbeddingVector)
            .HasConversion(converter);

        modelBuilder.Entity<CatEn>()
            .ToTable("Cats_EN")
            .Property(e => e.EmbeddingVector)
            .HasConversion(converter);
    }

    private static float[]? ParseFloatArray(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return null;
            
        try
        {
            // Clean the string - remove brackets and extra whitespace
            var cleanValue = value.Trim().Trim('[', ']');
            
            if (string.IsNullOrWhiteSpace(cleanValue))
                return new float[0];
                
            return cleanValue
                .Split(',')
                .Where(v => !string.IsNullOrWhiteSpace(v))
                .Select(v => {
                    var trimmed = v.Trim();
                    if (float.TryParse(trimmed, NumberStyles.Float, CultureInfo.InvariantCulture, out var result))
                        return result;
                    return 0f; // Default value for malformed entries
                })
                .ToArray();
        }
        catch
        {
            // Return empty array if parsing completely fails
            return new float[0];
        }
    }
}
