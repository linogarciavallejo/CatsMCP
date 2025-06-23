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
        return value.Split(',').Select(v => float.Parse(v, CultureInfo.InvariantCulture)).ToArray();
    }
}
