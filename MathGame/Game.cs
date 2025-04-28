namespace MathGame;

internal class Game
{
    private const char AdditionCharacter = '+';
    private const char DivisionCharacter = '/';
    private const char ExitCharacter = 'e';
    private const char HistoryCharacter = 'h';
    private const char MultiplicationCharacter = '*';
    private const char SubtractionCharacter = '-';
    private char _gameOperator;
    private int _result;

    internal Game(char gameOperator)
    {
        _gameOperator = gameOperator;
    }

    public int FirstValue { get; private set; }
    public int SecondValue { get; private set; }
    public int PlayerGuess { get; set; }

    internal void CalculateResult()
    {
        _result = _gameOperator switch
        {
            MultiplicationCharacter => FirstValue * SecondValue,
            DivisionCharacter => FirstValue / SecondValue,
            AdditionCharacter => FirstValue + SecondValue,
            SubtractionCharacter => FirstValue - SecondValue,
            _ => throw new InvalidOperationException()
        };
    }

    internal void DisplayGameQuestion()
    {
        Console.WriteLine("\n\nThe input should be a valid whole number");
        Console.Write($"Guess the answer {GetGameQuestion()}");
    }

    internal string GetGameQuestion() => $"{FirstValue} {_gameOperator} {SecondValue} = ";

    internal string GetGameQuestionWithResult() => $"{GetGameQuestion()} {_result}";

    internal bool IsDivision() => _gameOperator == DivisionCharacter;

    internal bool IsDivisionResultInteger() => FirstValue % SecondValue == 0;

    internal bool IsEnteredOptionABasicArithmenticOperation() => _gameOperator.Equals(MultiplicationCharacter) || _gameOperator.Equals(AdditionCharacter) || _gameOperator.Equals(SubtractionCharacter) || _gameOperator.Equals(DivisionCharacter);

    internal bool IsEnteredOptionForHistory() => char.ToLower(_gameOperator).Equals(char.ToLower(HistoryCharacter));

    internal bool IsEnteredOptionToExitGame() => char.ToLower(_gameOperator).Equals(char.ToLower(ExitCharacter));

    internal bool IsPlayerGuessAccurate() => PlayerGuess == _result;

    internal void setOperandValues(int firstValue, int secondValue)
    {
        FirstValue = firstValue;
        SecondValue = secondValue;
    }
}