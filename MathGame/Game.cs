namespace MathGame;

internal class Game
{
    private const char AdditionCharacter = '+';
    private const char DivisionCharacter = '/';
    private const char MultiplicationCharacter = '*';
    private const char SubtractionCharacter = '-';
    private const char HistoryCharacter = 'h';
    private const char ExitCharacter = 'e';
    private int operationResult;
    private int playerGuess;
    private int firstValue;
    private int secondValue;
    public char gameOperator;

    internal void DisplayMenu()
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

    internal void GenerateRandomValues()
    {
        Random randomValueGenerator = new Random();
        firstValue = randomValueGenerator.Next(101);
        secondValue = randomValueGenerator.Next(101);
    }

    internal bool IsDivision() => gameOperator == DivisionCharacter;

    internal bool IsDivisionResultInteger() => firstValue % secondValue == 0;

    internal void DisplayOperation()
    {
        Console.WriteLine("\nThe input should be a valid whole number");
        Console.WriteLine($"Guess the answer {firstValue} {gameOperator} {secondValue} = ");
    }

    internal void ExecuteGame()
    {
        bool isPlayerGuessInteger;
        do
        {
            DisplayOperation();
            isPlayerGuessInteger = int.TryParse(Console.ReadLine(), out playerGuess);
        } while (!isPlayerGuessInteger);
        operationResult = ExecuteOperation();
    }

    internal int ExecuteOperation() => gameOperator switch
    {
        MultiplicationCharacter => firstValue * secondValue,
        DivisionCharacter => firstValue / secondValue,
        AdditionCharacter => firstValue + secondValue,
        SubtractionCharacter => firstValue - secondValue,
        _ => throw new NotImplementedException()
    };

    internal bool IsEnteredOptionABasicArithmenticOperation() => gameOperator.Equals(MultiplicationCharacter) || gameOperator.Equals(AdditionCharacter) || gameOperator.Equals(SubtractionCharacter) || gameOperator.Equals(DivisionCharacter);

    internal bool IsEnteredOptionForHistory() => char.ToLower(gameOperator).Equals(char.ToLower(HistoryCharacter));

    internal bool IsEnteredOptionToExitGame() => char.ToLower(gameOperator).Equals(char.ToLower(ExitCharacter));

    internal bool IsPlayerGuessAccurate() => playerGuess == operationResult;
}