namespace MathGame;

internal class Program
{
    private const char AdditionCharacter = '+';
    private const char DivisionCharacter = '/';
    private const char HistoryCharacter = 'h';
    private const char MultiplicationCharacter = '*';
    private const char SubtractionCharacter = '-';
    private const char ExitCharacter = 'e';
    private static List<string> s_gameRecord = new List<string>();
    private static int s_operationResult;
    private static int s_playerGuess;
    private static int s_firstValue;
    private static int s_secondValue;

    private static void Main(string[] args)
    {
        bool continueGame = true;
        Console.WriteLine("Hello, Welcome to the Math Game\n");
        
        do
        {
            DisplayMenu();
            char menuOption = Console.ReadKey().KeyChar;
            if (IsEnteredOptionABasicArithmenticOperation(menuOption))
            {
                GenerateRandomValues();

                if (menuOption == DivisionCharacter)
                {
                    while (!IsDivisionResultInteger())
                    {
                        GenerateRandomValues();
                    }
                }

                ExecuteGame(menuOption);
                string gameResult = IsPlayerGuessAccurate() ? "Correct" : "Wrong";
                s_gameRecord.Add(gameResult);
                Console.WriteLine($"{gameResult}\n");
            }
            else if (IsEnteredOptionForHistory(menuOption))
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
            else if (IsEnteredOptionToExitGame(menuOption)) { 
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

    private static void DisplayMenu()
    {
        Console.WriteLine("You can test your arithmetic skills using the 4 basic artihmetic operations");
        Console.WriteLine("Please find the possible operations you can choose.\n");
        Console.WriteLine("\t* for Multiplication");
        Console.WriteLine("\t/ for Division");
        Console.WriteLine("\t- for Subtraction");
        Console.WriteLine("\t+ for Addition");
        Console.WriteLine("\tH or h to view game history\n");
        Console.WriteLine("\tE or e to exit game\n");
        Console.WriteLine("Please enter an option to start the game\n");
    }

    private static void GenerateRandomValues()
    {
        Random randomValueGenerator = new Random();
        s_firstValue = randomValueGenerator.Next(101);
        s_secondValue = randomValueGenerator.Next(101);
    }

    private static bool IsDivisionResultInteger() => s_firstValue % s_secondValue == 0;

    private static void DisplayOperation(char operation)
    {
        Console.WriteLine("\nThe input should be a valid whole number");
        Console.WriteLine($"Guess the answer {s_firstValue} {operation} {s_secondValue} = ");
    }

    private static void ExecuteGame(char menuOption)
    {
        bool isPlayerGuessInteger;
        do
        {
            DisplayOperation(menuOption);
            isPlayerGuessInteger = int.TryParse(Console.ReadLine(), out s_playerGuess);
        } while (!isPlayerGuessInteger);
        s_operationResult = ExecuteOperation(menuOption);
    }

    private static int ExecuteOperation(char operation) => operation switch
    {
        MultiplicationCharacter => s_firstValue * s_secondValue,
        DivisionCharacter => s_firstValue / s_secondValue,
        AdditionCharacter => s_firstValue + s_secondValue,
        SubtractionCharacter => s_firstValue - s_secondValue,
        _ => throw new NotImplementedException()
    };

    private static bool IsEnteredOptionABasicArithmenticOperation(char menuOption) => menuOption.Equals(MultiplicationCharacter) || menuOption.Equals(AdditionCharacter) || menuOption.Equals(SubtractionCharacter) || menuOption.Equals(DivisionCharacter);

    private static bool IsEnteredOptionForHistory(char menuOption) => char.ToLower(menuOption).Equals(char.ToLower(HistoryCharacter));
    private static bool IsEnteredOptionToExitGame(char menuOption) => char.ToLower(menuOption).Equals(char.ToLower(ExitCharacter));

    private static bool IsPlayerGuessAccurate() => s_playerGuess == s_operationResult;

}