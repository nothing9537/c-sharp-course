var numbers = new List<int> { 10, 12, -100, 55, -58, 17, 22 };
var FilteringStrategy = new FilteringStrategySelector();

Console.WriteLine("Select filter:");
Console.WriteLine(string.Join(Environment.NewLine, FilteringStrategy.GetFiltersNames));

var userInput = Console.ReadLine()!;

var filteringPredicate = FilteringStrategy.Select(userInput);
var res = new Filter().FilterBy(filteringPredicate, numbers);

Print(res);

Console.ReadKey();

void Print(IEnumerable<int> numbers)
{
    Console.WriteLine(string.Join(", ", numbers));
}

public class FilteringStrategySelector
{
    private readonly Dictionary<string, Func<int, bool>> _filtersMap = new Dictionary<string, Func<int, bool>>()
    {
        ["Even"] = (n) => n % 2 == 0,
        ["Odd"] = (n) => n % 2 == 1,
        ["Positive"] = (n) => n > 0,
        ["Negative"] = (n) => n < 0,
    };

    public IEnumerable<string> GetFiltersNames => _filtersMap.Keys;

    public Func<int, bool> Select(string userInput)
    {
        if (!_filtersMap.TryGetValue(userInput, out Func<int, bool>? value))
        {
            throw new NotSupportedException($"{userInput} is not a valid filter");
        }

        return value;
    }
}

public class Filter
{
    public IEnumerable<T> FilterBy<T>(Func<T, bool> predicate, IEnumerable<T> numbers)
    {
        var res = new List<T>();

        foreach (var number in numbers)
        {
            if (predicate(number))
            {
                res.Add(number);
            }
        }

        return res;
    }
}
