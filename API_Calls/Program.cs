using System.Text.Json;
using System.Text.Json.Serialization;

var baseUrl = "https://datausa.io/api/";
var queryUrl = "data?drilldowns=Nation&measures=Population";

var apiData = new APIReader();
var json = await apiData.Fetch(baseUrl, queryUrl);
var jsonData = JsonSerializer.Deserialize<Root>(json);

foreach (var yearlyData in jsonData.data)
{
    Console.WriteLine($"Year: {yearlyData.Year}, Population: {yearlyData.Population}");
}

Console.ReadKey();

public interface IAPIReader
{
    Task<string> Fetch(string baseUrl, string queryUrl);
}

public class APIReader : IAPIReader
{
    public async Task<string> Fetch(string baseUrl, string queryUrl)
    {
        using var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri(baseUrl);

        var response = await httpClient.GetAsync(queryUrl);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }
}

public record Annotations(
    [property: JsonPropertyName("source_name")] string source_name,
    [property: JsonPropertyName("source_description")] string source_description,
    [property: JsonPropertyName("dataset_name")] string dataset_name,
    [property: JsonPropertyName("dataset_link")] string dataset_link,
    [property: JsonPropertyName("table_id")] string table_id,
    [property: JsonPropertyName("topic")] string topic,
    [property: JsonPropertyName("subtopic")] string subtopic
);

public record Datum(
    [property: JsonPropertyName("ID Nation")] string IDNation,
    [property: JsonPropertyName("Nation")] string Nation,
    [property: JsonPropertyName("ID Year")] int IDYear,
    [property: JsonPropertyName("Year")] string Year,
    [property: JsonPropertyName("Population")] int Population,
    [property: JsonPropertyName("Slug Nation")] string SlugNation
);

public record Root(
    [property: JsonPropertyName("data")] IReadOnlyList<Datum> data,
    [property: JsonPropertyName("source")] IReadOnlyList<Source> source
);

public record Source(
    [property: JsonPropertyName("measures")] IReadOnlyList<string> measures,
    [property: JsonPropertyName("annotations")] Annotations annotations,
    [property: JsonPropertyName("name")] string name,
    [property: JsonPropertyName("substitutions")] IReadOnlyList<object> substitutions
);