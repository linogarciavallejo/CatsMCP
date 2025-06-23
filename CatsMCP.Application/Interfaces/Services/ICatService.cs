namespace CatsMCP.Application.Services;

public interface ICatService<T>
{
    Task<List<T>> GetCats();
    Task<T?> GetCat(string name);
}
