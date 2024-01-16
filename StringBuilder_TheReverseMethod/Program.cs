using System.Text;

public static class StringBuilderExercise
{
    public static string Reverse(string input)
    {
        var stringBuilder = new StringBuilder(input.Length);

        for (int i = input.Length; i >= 0; i--)
        {
            stringBuilder.Append(input[i]);
        }

        return stringBuilder.ToString();
    }
}