using System.Numerics;

int[] numbers = new int[] { 1, 2, 6, 19, 8, 7, 21 };

Console.WriteLine($"Is any number in a collection larger than 10? {IsAny<int>(numbers, (n) => n > 10)}");
Console.WriteLine($"Is any number in a collection even? {IsAny<int>(numbers, (n) => n % 2 == 0)}");

Console.ReadKey();

bool IsAny<T>(IEnumerable<int> numbers, Func<int, bool> Predicate) where T : INumber<T>
{
    foreach (var number in numbers)
    {
        if (Predicate(number))
        {
            return true;
        }
    }

    return false;
}