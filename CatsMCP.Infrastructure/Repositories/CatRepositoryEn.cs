using CatsMCP.Application.Interfaces.Repositories;
using CatsMCP.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatsMCP.Infrastructure.Repositories;

public class CatRepositoryEn : ICatRepositoryEn
{
    private readonly CatDbContext dbContext;

    public CatRepositoryEn(CatDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public Task<List<CatEn>> GetCats()
    {
        return dbContext.CatsEn.AsNoTracking().ToListAsync();
    }

    public Task<CatEn?> GetCat(string name)
    {
        return dbContext.CatsEn.AsNoTracking()
            .FirstOrDefaultAsync(c => c.Name != null &&
                c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }
}
