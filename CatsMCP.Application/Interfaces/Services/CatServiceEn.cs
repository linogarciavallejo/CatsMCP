using CatsMCP.Application.Interfaces.Repositories;
using CatsMCP.Domain.Entities;

namespace CatsMCP.Application.Services;

public class CatServiceEn : ICatService<CatEn>
{
    private readonly ICatRepositoryEn repository;

    public CatServiceEn(ICatRepositoryEn repository)
    {
        this.repository = repository;
    }

    public async Task<IEnumerable<CatEn>> GetCats()
    {
        var cats = await repository.GetCats();
        return cats;
    }

    public Task<CatEn?> GetCat(string name)
    {
        return repository.GetCat(name);
    }
}
