using System.Runtime.InteropServices;

namespace MathGame;

internal class GameManager
{
    private List<Game> _gameRecord = new List<Game>();

    internal void Run()
    {
        bool continueGame = true;
        Random randomValueGenerator = new Random();
        Console.WriteLine("Hello, Welcome to the Math Game\n");

        do
        {
            DisplayMenu();
            Game game = new Game(gameOperator: Console.ReadKey().KeyChar);
            
            if (game.IsEnteredOptionABasicArithmenticOperation())
            {
                game.setOperandValues(randomValueGenerator.Next(101), randomValueGenerator.Next(101));

                if (game.IsDivision())
                {
                    while (!game.IsDivisionResultInteger())
                    {
                        game.setOperandValues(randomValueGenerator.Next(101), randomValueGenerator.Next(101));
                    }
                }

                bool isPlayerGuessInteger;
                int playerGuess;
                do
                {
                    game.DisplayGameQuestion();
                    isPlayerGuessInteger = int.TryParse(Console.ReadLine(), out playerGuess);
                } while (!isPlayerGuessInteger);
                game.setPlayerGuess(playerGuess);
                game.CalculateResult();
                _gameRecord.Add(game);
                Console.WriteLine($"{(game.IsPlayerGuessAccurate() ? "Correct" : "Wrong")} answer\n");
            }
            else if (game.IsEnteredOptionForHistory())
            {
                if (_gameRecord.Count == 0)
                {
                    Console.WriteLine("No games played till now");
                }
                else
                {
                    Console.WriteLine($"\nGame History\n");
                    for (int i = 0; i < _gameRecord.Count; i++)
                    {
                        Game record = _gameRecord[i];
                        Console.WriteLine($"Game {i + 1}. {record.GetGameQuestionWithResult()} || Provided answer {record.GetPlayerGuess()} was {(game.IsPlayerGuessAccurate() ? "Correct" : "Wrong")}.\n");
                    }
                }
                Thread.Sleep(1800);
            }
            else if (game.IsEnteredOptionToExitGame())
            {
                continueGame = false;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Please enter a valid menu option\n");
                Thread.Sleep(800);

            }
        } while (continueGame);
    }

    private void DisplayMenu()
    {
        Console.WriteLine("You can test your arithmetic skills using the 4 basic artihmetic operations");
        Console.WriteLine("Please find the possible operations you can choose.\n");
        Console.WriteLine("\t* for Multiplication");
        Console.WriteLine("\t/ for Division");
        Console.WriteLine("\t- for Subtraction");
        Console.WriteLine("\t+ for Addition");
        Console.WriteLine("\tH or h to view game history\n");
        Console.WriteLine("\tE or e to exit game\n");
        Console.Write("Please enter an option to start the game: ");
    }
}
