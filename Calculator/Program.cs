List<int> numbers = new List<int> { 1, 4, 5, -1, 6, -9, 13, -18 };
bool shallAddPositiveOnly = false;

NumbersSumCalculator calculator = shallAddPositiveOnly
    ? new PositiveNumbersSumCalculator()
    : new NumbersSumCalculator();

int sum = calculator.Calculate(numbers);

Console.WriteLine($"Sum is: {sum}");
Console.ReadKey();

public class NumbersSumCalculator
{
    public int Calculate(List<int> numbers)
    {
        int sum = 0;

        foreach (int number in numbers)
        {
            if (ShallNumberBeAdded(number))
            {
                sum += number;
            }
        }

        return sum;
    }

    protected virtual bool ShallNumberBeAdded(int value)
    {
        return true;
    }
}

public class PositiveNumbersSumCalculator : NumbersSumCalculator
{
    protected override bool ShallNumberBeAdded(int value)
    {
        return value > 0;
    }
}