using System.Text.Json;

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
            z
            return JsonSerializer.Deserialize<List<VideoGame>>(fileData);
        }
        else
        {
            return new List<VideoGame>();
        }
    }
}
