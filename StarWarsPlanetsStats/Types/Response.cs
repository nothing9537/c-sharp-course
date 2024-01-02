using System.Text.Json.Serialization;

namespace StarWarsPlanetsStats.Types;

public record Result(
    [property: JsonPropertyName("name")] string name,
    [property: JsonPropertyName("rotation_period")] string rotation_period,
    [property: JsonPropertyName("orbital_period")] string orbital_period,
    [property: JsonPropertyName("diameter")] string diameter,
    [property: JsonPropertyName("climate")] string climate,
    [property: JsonPropertyName("gravity")] string gravity,
    [property: JsonPropertyName("terrain")] string terrain,
    [property: JsonPropertyName("surface_water")] string surface_water,
    [property: JsonPropertyName("population")] string population,
    [property: JsonPropertyName("residents")] IReadOnlyList<string> residents,
    [property: JsonPropertyName("films")] IReadOnlyList<string> films,
    [property: JsonPropertyName("created")] DateTime created,
    [property: JsonPropertyName("edited")] DateTime edited,
    [property: JsonPropertyName("url")] string url
);

public record ResultSubset(
    [property: JsonPropertyName("Name")] string Name,
    [property: JsonPropertyName("Diameter")] string Diameter,
    [property: JsonPropertyName("SurfaceWater")] string SurfaceWater,
    [property: JsonPropertyName("Population")] string Population
)
{
    public ResultSubset(Result res) : this(res.name, res.diameter, res.surface_water, res.population) { }
}

public record PlanetsResponse(
    [property: JsonPropertyName("count")] int count,
    [property: JsonPropertyName("next")] string next,
    [property: JsonPropertyName("previous")] object previous,
    [property: JsonPropertyName("results")] IReadOnlyList<Result> results
);
