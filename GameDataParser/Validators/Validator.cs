namespace GameDataParser.Validator;

using System.Text.Json;
using GameDataParser.Entities;

static class Validator
{
    public static bool IsUserInputValid(string input)
    {
        if (input is null)
        {
            Console.WriteLine("File name cannot be null.");

            return false;
        }
        else if (input == string.Empty)
        {
            Console.WriteLine("File name cannot be empty.");

            return false;
        }
        else if (!File.Exists(input))
        {
            Console.WriteLine("File not found.");

            return false;
        }

        return true;
    }

    public static bool IsFileDataValid(string filePath)
    {
        try
        {
            var fileData = File.ReadAllText(filePath);

            Console.WriteLine(fileData);

            _ = JsonSerializer.Deserialize<List<VideoGame>>(fileData);

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"JSON in the {filePath} was not in a valid format. JSON body: {ex.Message}");

            return false;
        }
    }
}