class ValidationHandler
{
    public static bool IsUserInputValid(string userInput, out int number, int maxSides)
    {
        bool isValid = int.TryParse(userInput, out number);

        if (number < 1 || number > maxSides)
        {
            return false;
        }

        return isValid;
    }
}