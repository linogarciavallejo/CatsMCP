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

    public Task<List<CatEn>> GetCats()
    {
        return repository.GetCats();
    }

    public Task<CatEn?> GetCat(string name)
    {
        return repository.GetCat(name);
    }
}
