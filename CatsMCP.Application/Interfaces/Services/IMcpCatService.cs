namespace CatsMCP.Application.Services;

public interface IMcpCatService
{
    Task<IEnumerable<object>> GetCats();
    Task<object?> GetCat(string name);
}
