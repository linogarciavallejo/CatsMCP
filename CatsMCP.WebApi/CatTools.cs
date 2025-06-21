using CatsMCP.Application.Services;
using ModelContextProtocol.Server;
using System.ComponentModel;
using System.Text.Json;

namespace CatsMCP.WebApi;

[McpServerToolType]
public static class CatTools
{
    [McpServerTool, Description("Get a list of cats.")]
    public static async Task<string> GetCats(CatService catService)
    {
        var cats = await catService.GetCats();
        return JsonSerializer.Serialize(cats);
    }

    [McpServerTool, Description("Get a cat by name.")]
    public static async Task<string> GetCat(CatService catService, [Description("The name of the cat to get details for")] string name)
    {
        var cat = await catService.GetCat(name);
        return JsonSerializer.Serialize(cat);
    }


}