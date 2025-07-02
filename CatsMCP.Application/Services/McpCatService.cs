using CatsMCP.Domain.Entities;

namespace CatsMCP.Application.Services;

public class McpCatService : IMcpCatService
{
    private readonly ICatService<Cat> _catService;

    public McpCatService(ICatService<Cat> catService)
    {
        _catService = catService;
    }

    public async Task<IEnumerable<object>> GetCats()
    {
        var cats = await _catService.GetCats();
        return cats.Cast<object>();
    }

    public async Task<object?> GetCat(string name)
    {
        return await _catService.GetCat(name);
    }
}
