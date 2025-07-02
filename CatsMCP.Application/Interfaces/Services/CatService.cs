using CatsMCP.Application.Interfaces.Repositories;
using CatsMCP.Domain.Entities;

namespace CatsMCP.Application.Services;

public class CatService : ICatService<Cat>
{
    private readonly ICatRepository repository;

    public CatService(ICatRepository repository)
    {
        this.repository = repository;
    }

    public async Task<IEnumerable<Cat>> GetCats()
    {
        var cats = await repository.GetCats();
        return cats;
    }

    public Task<Cat?> GetCat(string name)
    {
        return repository.GetCat(name);
    }
}
