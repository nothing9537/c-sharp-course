namespace Pizza.Extensions
{
    public static class StringExtensions
    {
        public static int LinesCount(this string input) => input.Split(Environment.NewLine).Length;
    }
}
