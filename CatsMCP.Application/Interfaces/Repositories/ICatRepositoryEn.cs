namespace CatsMCP.Application.Interfaces.Repositories;

using CatsMCP.Domain.Entities;

public interface ICatRepositoryEn
{
    Task<List<CatEn>> GetCats();
    Task<CatEn?> GetCat(string name);
}
