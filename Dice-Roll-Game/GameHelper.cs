namespace Dice_Roll_Game.Helper;

class GameHelper(DiceGame game)
{
    private DiceGame _game = game;

    public int HandleUserInput()
    {
        while (true)
        {
            Console.WriteLine($"Enter number between 1 - {_game.SidesCount}:");

            bool isNumberInputValid = ValidationHandler.IsUserInputValid(Console.ReadLine()!, out int userNumber, _game.SidesCount);

            if (!isNumberInputValid)
            {
                continue;
            }
            else
            {
                return userNumber;
            }
        }
    }
}