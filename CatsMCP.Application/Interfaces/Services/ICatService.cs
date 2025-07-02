namespace CatsMCP.Application.Services;

public interface ICatService<T>
{
    Task<IEnumerable<T>> GetCats();
    Task<T?> GetCat(string name);
}
