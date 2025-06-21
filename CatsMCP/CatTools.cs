using ModelContextProtocol.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CatsMCP;

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