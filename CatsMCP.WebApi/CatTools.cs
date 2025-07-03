using CatsMCP.Application.Services;
using CatsMCP.Application.Interfaces.Repositories;
using CatsMCP.Domain.Entities;
using ModelContextProtocol.Server;
using System.ComponentModel;
using System.Text.Json;

namespace CatsMCP.WebApi;

[McpServerToolType]
public static class CatTools
{
    [McpServerTool, Description("Get a list of cats with language support.")]
    public static async Task<string> GetCats(
        IServiceProvider serviceProvider,
        [Description("Language preference: 'en' for English, 'es' for Spanish (default: 'en')")]
        string language = "en")
    {
        using var scope = serviceProvider.CreateScope();
        
        if (language.ToLower() == "es")
        {
            var catService = scope.ServiceProvider.GetRequiredService<ICatService<Cat>>();
            var cats = await catService.GetCats();
            return JsonSerializer.Serialize(cats);
        }
        else
        {
            var catServiceEn = scope.ServiceProvider.GetRequiredService<ICatService<CatEn>>();
            var cats = await catServiceEn.GetCats();
            return JsonSerializer.Serialize(cats);
        }
    }

    [McpServerTool, Description("Get a cat by name with language support.")]
    public static async Task<string> GetCat(
        IServiceProvider serviceProvider,
        [Description("The name of the cat to get details for")] string name,
        [Description("Language preference: 'en' for English, 'es' for Spanish (default: 'en')")]
        string language = "en")
    {
        using var scope = serviceProvider.CreateScope();
        
        if (language.ToLower() == "es")
        {
            var catService = scope.ServiceProvider.GetRequiredService<ICatService<Cat>>();
            var cat = await catService.GetCat(name);
            return JsonSerializer.Serialize(cat);
        }
        else
        {
            var catServiceEn = scope.ServiceProvider.GetRequiredService<ICatService<CatEn>>();
            var cat = await catServiceEn.GetCat(name);
            return JsonSerializer.Serialize(cat);
        }
    }

    [McpServerTool, Description("Echo a message back to test the MCP connection.")]
    public static async Task<string> Echo(
        [Description("The message to echo back")] string message)
    {
        return $"Echo: {message}";
    }

    [McpServerTool, Description("Reverse echo a message back to test the MCP connection.")]
    public static async Task<string> ReverseEcho(
        [Description("The message to reverse and echo back")] string message)
    {
        var reversed = new string(message.Reverse().ToArray());
        return $"Reverse Echo: {reversed}";
    }
}