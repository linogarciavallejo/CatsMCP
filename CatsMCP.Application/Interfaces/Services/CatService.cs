using CatsMCP.Application.Interfaces.Repositories;
using CatsMCP.Domain.Entities;

namespace CatsMCP.Application.Services;

public class CatService
{
    private readonly ICatRepository repository;

    public CatService(ICatRepository repository)
    {
        this.repository = repository;
    }

    public Task<List<Cat>> GetCats()
    {
        return repository.GetCats();
    }

    public Task<Cat?> GetCat(string name)
    {
        return repository.GetCat(name);
    }
}
