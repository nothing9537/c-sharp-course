foreach (var fibNum in CheckedFibonacciExercise.GetFibonacci(48))
{
    Console.WriteLine(fibNum);
}

Console.ReadKey();

public static class CheckedFibonacciExercise
{
    public static IEnumerable<int> GetFibonacci(int n)
    {
        checked
        {
            int firstItem = -1;
            int secondItem = 1;

            for (int i = 0; i < n; i++)
            {
                int sum = firstItem + secondItem;

                firstItem = secondItem;
                secondItem = sum;

                yield return sum;
            }
        }
    }
}