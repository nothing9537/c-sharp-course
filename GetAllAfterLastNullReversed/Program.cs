public class YieldExercise
{
    public static IEnumerable<T> GetAllAfterLastNullReversed<T>(IList<T> input)
    {
        for (int i = input.Count - 1; i >= 0; i--)
        {
            var element = input[i];

            if (element is null)
            {
                yield break;
            }
            else
            {
                yield return element;
            }
        }
    }
}