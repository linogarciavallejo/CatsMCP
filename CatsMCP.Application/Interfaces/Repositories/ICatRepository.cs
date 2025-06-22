namespace CatsMCP.Application.Interfaces.Repositories;

using CatsMCP.Domain.Entities;

public interface ICatRepository
{
    Task<List<Cat>> GetCats();
    Task<Cat?> GetCat(string name);
}
