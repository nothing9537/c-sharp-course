public class Exercise
{
    public static double CalculateAverageDurationInMilliseconds(IEnumerable<TimeSpan> timeSpans)
    {
        return timeSpans.Select(timeSpan => timeSpan.TotalMilliseconds).Average();
    }
}