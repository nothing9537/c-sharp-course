using StarWarsPlanetsStats.Types;

namespace StarWarsPlanetsStats.Transforms;

public static class MainTransform
{
    public static List<ResultSubset> TransformToSubset(IReadOnlyList<Result> data)
    {
        var transformedData = new List<ResultSubset>();

        foreach (var item in data)
        {
            transformedData.Add(new ResultSubset(item));
        }

        return transformedData;
    }
}
