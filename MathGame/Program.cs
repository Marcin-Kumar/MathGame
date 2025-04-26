namespace MathGame;

internal class Program
{
    private static List<string> s_gameRecord = new List<string>();

    private static void Main(string[] args)
    {
        bool continueGame = true;
        Console.WriteLine("Hello, Welcome to the Math Game\n");
        
        do
        {
            Game game = new Game();

            game.DisplayMenu();
            game.gameOperator = Console.ReadKey().KeyChar;
            if (game.IsEnteredOptionABasicArithmenticOperation())
            {
                game.GenerateRandomValues();

                if (game.IsDivision())
                {
                    while (!game.IsDivisionResultInteger())
                    {
                        game.GenerateRandomValues();
                    }
                }

                game.ExecuteGame();
                string gameResult = game.IsPlayerGuessAccurate() ? "Correct" : "Wrong";
                s_gameRecord.Add(gameResult);
                Console.WriteLine($"{gameResult}\n");
            }
            else if (game.IsEnteredOptionForHistory())
            {
                if (s_gameRecord.Count == 0)
                {
                    Console.WriteLine("No games played till now");
                }
                else
                {
                    Console.WriteLine($"Game History\n");
                    foreach (var item in s_gameRecord)
                    {
                        Console.WriteLine(item);
                    }
                }
                Thread.Sleep(1800);
            }
            else if (game.IsEnteredOptionToExitGame()) { 
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
}