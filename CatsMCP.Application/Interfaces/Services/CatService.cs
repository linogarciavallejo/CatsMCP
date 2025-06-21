using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CatsMCP.Application.Services;

public class CatService
{
    private readonly HttpClient httpClient;
    public CatService(IHttpClientFactory httpClientFactory)
    {
        httpClient = httpClientFactory.CreateClient();
    }

    List<Cat> catList = new();
    public async Task<List<Cat>> GetCats()
    {
        if (catList?.Count > 0)
            return catList;

        var response = await httpClient.GetAsync("http://localhost:8088/felinos.json");
        if (response.IsSuccessStatusCode)
        {
            catList = await response.Content.ReadFromJsonAsync(CatContext.Default.ListCat) ?? new List<Cat>();
        }

        return catList;
    }

    public async Task<Cat?> GetCat(string name)
    {
        var cats = await GetCats();
        return cats.FirstOrDefault(m => m.Nombre?.Equals(name, StringComparison.OrdinalIgnoreCase) == true);
    }
}

public class CatHistory
{
    [JsonPropertyName("veces_enfermo")] // Maps JSON "veces_enfermo" to C# VecesEnfermo
    public int VecesEnfermo { get; set; }

    [JsonPropertyName("porciones_atun_oz_mensual")] // Maps JSON array to C# List<int>
    public List<int> PorcionesAtunOzMensual { get; set; }
}

public class Cat
{
    [JsonPropertyName("nombre")] // Maps JSON "nombre" to C# Nombre
    public string Nombre { get; set; }

    [JsonPropertyName("raza")] // Maps JSON "raza" to C# Raza
    public string Raza { get; set; }

    [JsonPropertyName("edad")] // Maps JSON "edad" to C# Edad (string to handle "X años")
    public string Edad { get; set; }

    [JsonPropertyName("sexo")] // Maps JSON "sexo" to C# Sexo
    public string Sexo { get; set; }

    // Using bool? (nullable boolean) because 'esterilizado' might be missing
    // in the JSON for male cats. It will deserialize as null if absent.
    [JsonPropertyName("esterilizado")]
    public bool? Esterilizado { get; set; }

    [JsonPropertyName("historia_ultimos_6_meses")] // Maps nested JSON object to C# CatHistory object
    public CatHistory HistoriaUltimos6Meses { get; set; }
}

[JsonSerializable(typeof(List<Cat>))]
internal sealed partial class CatContext : JsonSerializerContext
{
}
