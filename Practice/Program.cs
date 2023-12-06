public static class ExceptionsRethrowing
{
    public static int GetMaxValue(List<int> numbers)
    {
        try
        {
            return numbers.Max();
        }
        catch (ArgumentNullException)
        {
            throw new ArgumentNullException("The numbers list cannot be null.");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine("The numbers list cannot be empty.");
            throw ex;
        }
    }
}