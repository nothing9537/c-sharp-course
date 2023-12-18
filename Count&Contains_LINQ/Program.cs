public class Exercise
{
    public static int CountListsContainingZeroLongerThan(int length, List<List<int>> listsOfNumbers)
    {
        return listsOfNumbers.Count(l => l.Contains(0) && l.Count() > length);
    }
}