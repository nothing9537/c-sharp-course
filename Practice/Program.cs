var numbers = new List<int> {  };

foreach (var item in numbers.TakeEverySecond())
{
    Console.WriteLine(item);
}

Console.ReadKey();

public static class ListExtentions
{
    public static List<int> TakeEverySecond(this List<int> numbers)
    {
        var result = new List<int>();

        for (int i = 0; i < numbers.Count; i += 2)
        {
            result.Add(numbers[i]);
        }

        return result;
    }
}