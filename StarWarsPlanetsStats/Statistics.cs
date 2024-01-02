using StarWarsPlanetsStats.Types;
using StarWarsPlanetsStats.Validate;

namespace StarWarsPlanetsStats;

public class Statistics(List<ResultSubset> data, IEnumerable<string> options)
{
    private readonly List<ResultSubset> _data = data;
    private readonly IEnumerable<string> _options = options;

    public void DisplayStatistics()
    {
        Console.WriteLine("\nThe statistics of which property you would like to see?");

        foreach (var option in _options)
        {
            Console.WriteLine(option);
        }

        var userChoice = HandleUserInput();

        switch (userChoice)
        {
            case "populations":
                HandlePopulationOption("Population");
                break;
            case "diameter":
                HandlePopulationOption("Diameter");
                break;
            case "surface water":
                HandlePopulationOption("SurfaceWater");
                break;
            default:
                Console.WriteLine("Unexpected choice.");
                break;
        }
    }

    private string HandleUserInput()
    {
        string userInput = "";
        bool isUserInputValid = false;

        while (!isUserInputValid)
        {
            userInput = Console.ReadLine()!.ToLower();
            isUserInputValid = Validator.ValidateUserInput(userInput, _options);
        }

        return userInput;
    }

    private void HandlePopulationOption(string fieldName)
    {
        if (string.IsNullOrWhiteSpace(fieldName))
        {
            Console.WriteLine("Invalid field name.");
            return;
        }

        var property = typeof(ResultSubset).GetProperty(fieldName);

        if (property == null)
        {
            Console.WriteLine($"Field '{fieldName}' not found in the data type.");
            return;
        }

        var sorted = _data.OrderByDescending(option =>
        {
            _ = decimal.TryParse(property.GetValue(option)?.ToString(), out decimal value);

            return value;
        }).Where(option =>
        {
            _ = decimal.TryParse(property.GetValue(option)?.ToString(), out decimal value);

            return value != 0;
        });

        var minOption = sorted.First();
        var maxOption = sorted.Last();

        Console.WriteLine($"Max {fieldName} is {property.GetValue(maxOption)} (planet: {maxOption.Name})");
        Console.WriteLine($"Min {fieldName} is {property.GetValue(minOption)} (planet: {minOption.Name})");
    }
}
