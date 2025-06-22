using CatsMCP.Infrastructure.Entities;
using CatsMCP.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CatsMCP.Application.Services;

public class CatService
{
    private readonly CatDbContext dbContext;

    public CatService(CatDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public Task<List<Cat>> GetCats()
    {
        return dbContext.Cats.AsNoTracking().ToListAsync();
    }

    public Task<Cat?> GetCat(string name)
    {
        return dbContext.Cats.AsNoTracking()
            .FirstOrDefaultAsync(c => c.Nombre != null &&
                c.Nombre.Equals(name, StringComparison.OrdinalIgnoreCase));
    }
}
