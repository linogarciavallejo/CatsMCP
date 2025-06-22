namespace CatsMCP.Application.Services;

public interface ICatService
{
    Task<List<object>> GetCats();
    Task<object?> GetCat(string name);
}
