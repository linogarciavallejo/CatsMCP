using CatsMCP.Application.Interfaces.Repositories;
using CatsMCP.Domain.Entities;

namespace CatsMCP.Application.Services;

public class CatServiceEn : ICatService
{
    private readonly ICatRepositoryEn repository;

    public CatServiceEn(ICatRepositoryEn repository)
    {
        this.repository = repository;
    }

    public async Task<List<object>> GetCats()
    {
        var result = await repository.GetCats();
        return result.Cast<object>().ToList();
    }

    public async Task<object?> GetCat(string name)
    {
        return await repository.GetCat(name);
    }
}
