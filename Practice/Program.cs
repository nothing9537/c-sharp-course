var numbers = new List<int> { 1, 2, 3, 7, 9, 15, -5, 0 };
numbers.AddToFront<int>(-7);

var decimals = new List<decimal> { 1m, 2.2m, 5m, 9.6m, 8.3m };
var ints = decimals.ConvertTo<decimal, int>();

Tuple<int, int> minAndMax = GetMinAndMax(numbers);
Console.WriteLine($"Min in a collection is: {minAndMax.Item1}");
Console.WriteLine($"Max in a collection is: {minAndMax.Item2}");

Console.ReadKey();

Tuple<int, int> GetMinAndMax(IEnumerable<int> input)
{
    if (!input.Any())
    {
        throw new InvalidOperationException("The input cannot be empty.");
    }

    int min = input.First();
    int max = input.First();

    foreach (var number in input)
    {
        if (number > max)
        {
            max = number;
        }

        if (number < min)
        {
            min = number;
        }
    }

    return new Tuple<int, int>(min, max);
}

static class ListExtentions
{
    public static void AddToFront<T>(this List<T> sourceList, T item)
    {
        sourceList.Insert(0, item);
    }

    public static List<TTarget> ConvertTo<TSource, TTarget>(this List<TSource> sourceList)
    {
        var res = new List<TTarget>();

        foreach (var item in sourceList)
        {
            res.Add((TTarget)item);
        }

        return res;
    }
}