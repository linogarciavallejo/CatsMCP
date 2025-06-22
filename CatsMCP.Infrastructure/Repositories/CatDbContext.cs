using CatsMCP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CatsMCP.Infrastructure.Repositories;

public class CatDbContext : DbContext
{
    public CatDbContext(DbContextOptions<CatDbContext> options) : base(options)
    {
    }

    public DbSet<Cat> Cats => Set<Cat>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var converter = new ValueConverter<float[]?, string?>(
            v => v == null ? null : string.Join(',', v),
            v => string.IsNullOrEmpty(v) ? null : v.Split(',').Select(float.Parse).ToArray());

        modelBuilder.Entity<Cat>()
            .Property(e => e.EmbeddingVector)
            .HasConversion(converter);
    }
}
