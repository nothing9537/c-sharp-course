using Dice_Roll_Game.Helper;
namespace Dice_Roll_Game;

public enum GameResult
{
    Victory,
    Loss
}

class DiceGame
{
    private readonly Random _random;
    private int Answer { get; init; }
    private int UserTries { get; set; }
    public int SidesCount { get; init; }

    public DiceGame(Random random, int diceSides, int triesToGuess)
    {
        _random = random;
        SidesCount = diceSides;

        UserTries = triesToGuess;
        Answer = _random.Next(1, SidesCount + 1);
    }

    public GameResult Play()
    {
        Console.WriteLine($"Dice with {SidesCount} has been rolled. Guess what number is shows in {UserTries} tries.");

        while (UserTries != 0)
        {
            int userNumber = new GameHelper(this).HandleUserInput();

            if (userNumber == Answer)
            {
                return GameResult.Victory;
            }
            else
            {
                UserTries--;
                Console.WriteLine("Wrong number :(. Try again!");
                Console.WriteLine($"You have {UserTries} chances to guess the number.");
            }
        }

        return GameResult.Loss;
    }

    public void PrintGameResult(GameResult result)
    {
        Console.WriteLine(result == GameResult.Victory ? "You win! :)" : "You loss :(");
    }
}