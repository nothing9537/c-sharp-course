using System.Numerics;

int[] numbers = new int[] { 1, 2, 6, 19, 8, 7, 21 };

Console.WriteLine($"Is any number in a collection larger than 10? + {IsAny<int>(numbers, IsLargwerThan10<int>)}");
Console.WriteLine($"Is any number in a collection even? + {IsAny<int>(numbers, IsEven<int>)}");

Console.ReadKey();

bool IsLargwerThan10<T>(int number) where T : INumber<T> => number > 10;
bool IsEven<T>(int number) where T : INumber<T> => number % 2 == 0;

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