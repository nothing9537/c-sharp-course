public static class FloatingPointNumbersExercise
{
    public static bool IsAverageEqualTo(this IEnumerable<double> input, double valueToBeChecked, double precision = 0.00001d)
    {
        bool isInputContainsNonValidMembers = input.Any(doubleNum => double.IsNaN(doubleNum) || double.IsInfinity(doubleNum));

        if (isInputContainsNonValidMembers)
        {
            throw new ArgumentException("Input list contains NaN or Infinity so it's impossible to calculate an average.");
        }

        double averageInInput = input.Average();

        return Math.Abs(averageInInput - valueToBeChecked) < precision;
    }
}