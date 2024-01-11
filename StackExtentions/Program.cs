public static class StackExtensions
{
    public static bool DoesContainAny(this Stack<string> input, params string[] words)
    {
        foreach (var item in words)
        {
            if (input.Contains(item))
            {
                return true;
            }
        }

        return false;
    }
}