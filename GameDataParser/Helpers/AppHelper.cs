namespace GameDataParser.Helper;

using System.Text.Json;
using GameDataParser.Validator;
using GameDataParser.Entities;

class AppHelper
{
    public string ReadUserInput()
    {
        bool isUserInputValid = false;
        string userInput = "";

        while (!isUserInputValid)
        {
            userInput = Console.ReadLine()!;

            isUserInputValid = Validator.IsUserInputValid(userInput);
        }

        return userInput;
    }

    public List<VideoGame> ReadDataFromFile(string userInputFileName)
    {
        bool isFileDataValid = Validator.IsFileDataValid(userInputFileName);

        if (isFileDataValid)
        {
            var fileData = File.ReadAllText(userInputFileName);

            Console.WriteLine(fileData);

            return JsonSerializer.Deserialize<List<VideoGame>>(fileData);
        }
        else
        {
            return new List<VideoGame>();
        }
    }
}
