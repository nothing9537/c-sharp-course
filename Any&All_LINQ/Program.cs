public class Exercise
{
    public static bool IsAnyWordWhiteSpace(List<string> words)
    {
        return words.Any(word => word.All(@char => char.IsWhiteSpace(@char)));
    }
}