public static class RefModifierFastForwardToSummerExercise
{
    public static void FastForwardToSummer(ref DateTime timestamp)
    {
        var firstDayOfSummer = new DateTime(timestamp.Year, 6, 21);
        if (timestamp < firstDayOfSummer)
        {
            timestamp = firstDayOfSummer;
        }
    }
}