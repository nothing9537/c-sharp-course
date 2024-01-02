using StarWarsPlanetsStats.Interfaces;
using System.Text.Json;

namespace StarWarsPlanetsStats.API;

public class APICaller : IAPICaller
{
    public async Task<T> Fetch<T>(string baseUrl, string queryUrl) where T : class
    {
        using var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri(baseUrl);

        var response = await httpClient.GetAsync(queryUrl);

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<T>(json);
    }
}