using Dice_Roll_Game;

var random = new Random();
var game = new DiceGame(random, 6, 3);

GameResult gameResult =  game.Play();

Console.WriteLine(gameResult == GameResult.Victory ? "You win! :)" : "You loss :(");
Console.ReadKey();