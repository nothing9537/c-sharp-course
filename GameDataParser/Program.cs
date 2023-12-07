using System.Text.Json;

try
{
    var app = new App();
    app.Init();
}
catch (Exception ex)
{
    Console.WriteLine("An unexpected message was occured." + ex.Message);
    // Write ex.Message to .log file.
}

Console.ReadKey();

 public class VideoGame
{
    public string Title { get; init; }
    public int ReleaseYear { get; init; }
    public decimal Rating { get; init; }
}

class App
{
    private readonly AppHelper _helper;
    public App()
    {
        _helper = new AppHelper();
    }
    public void Init()
    {
        Console.WriteLine("Enter the name of the file you want to read:");

        var userInput = _helper.ReadUserInput();
        var games = _helper.ReadDataFromFile(userInput);

        DisplayGames(games);
    }

    private void DisplayGames(List<VideoGame> videoGames)
    {
        if (videoGames.Count > 0)
        {
            Console.WriteLine("Loaded games are:");

            foreach (var game in videoGames)
            {
                Console.WriteLine($"{game.Title}, realised in {game.ReleaseYear}, rating: {game.Rating}");
            }
        }
        else
        {
            Console.WriteLine("No games are present in the input file.");
        }
    }
}

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
            var videoGames = JsonSerializer.Deserialize<List<VideoGame>>(fileData);
            return videoGames;
        }
        else
        {
            return new List<VideoGame>();
        }
    }
}

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

        return true;
    }

    public static bool IsFileDataValid(string filePath)
    {
        if (File.Exists(filePath))
        {
            try
            {
                var fileData = File.ReadAllText(filePath);
                Console.WriteLine(fileData);
                JsonSerializer.Deserialize<List<VideoGame>>(fileData);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"JSON in the {filePath} was not in a valid format. JSON body: {ex.Message}");

                return false;
            }
        }
        else
        {
            Console.WriteLine("File not found.");
            return false;
        }
    }
}