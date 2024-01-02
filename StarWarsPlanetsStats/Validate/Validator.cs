namespace StarWarsPlanetsStats.Validate;

public static class Validator
{
    public static bool ValidateUserInput(string userInput, IEnumerable<string> validOptions)
    {
        bool isValid = validOptions.Any(option => option == userInput);

        if (!isValid)
        {
            Console.WriteLine("Invalid choice.");
        }

        return isValid;
    }
}
