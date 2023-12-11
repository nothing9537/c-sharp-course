var numbers = new List<int> { 1, 2, 3, 7, 9, 15, -5, 0 };
SimpleTuple<int, int> minAndMax = GetMinAndMax(numbers);
Console.WriteLine($"Min in a collection is: {minAndMax.Item1}");
Console.WriteLine($"Max in a collection is: {minAndMax.Item2}");
Console.ReadKey();

SimpleTuple<int, int> GetMinAndMax(IEnumerable<int> input)
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

    return new SimpleTuple<int, int>(min, max);
}
class SimpleTuple<T1, T2>
{
    public T1 Item1;
    public T2 Item2;

    public SimpleTuple(T1 item1, T2 item2)
    {
        Item1 = item1;
        Item2 = item2;
    }
}