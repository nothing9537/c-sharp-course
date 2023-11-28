public static class StringsTransformator
{
    public static string TransformSeparators(
        string input,
        string originalSeparator,
        string targetSeparator
        ) => string.Join(targetSeparator, input.Split(originalSeparator));
}