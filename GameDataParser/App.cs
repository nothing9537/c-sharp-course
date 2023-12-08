
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
                Console.WriteLine(game);
            }
        }
        else
        {
            Console.WriteLine("No games are present in the input file.");
        }
    }
}
