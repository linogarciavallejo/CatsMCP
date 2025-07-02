using CatsMCP.Application.Interfaces.Repositories;
using CatsMCP.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatsMCP.Infrastructure.Repositories;

public class CatRepository : ICatRepository
{
    private readonly CatDbContext dbContext;

    public CatRepository(CatDbContext dbContext)
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
                c.Nombre.ToLower() == name.ToLower());
    }
}
