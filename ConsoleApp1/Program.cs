public class Exercise
{
    public static string FindShortestWord(List<string> words)
    {
        return words.OrderBy(word => word.Length).First();
    }
}