namespace MathGame;

internal class Game
{
    private const char AdditionCharacter = '+';
    private const char DivisionCharacter = '/';
    private const char ExitCharacter = 'e';
    private const char HistoryCharacter = 'h';
    private const char MultiplicationCharacter = '*';
    private const char SubtractionCharacter = '-';
    private int _firstValue;
    private char _gameOperator;
    private int _playerGuess;
    private int _result;
    private int _secondValue;
    internal Game(char gameOperator)
    {
        _gameOperator = gameOperator;
    }

    internal void DisplayGameQuestion()
    {
        Console.WriteLine("\nThe input should be a valid whole number");
        Console.WriteLine($"Guess the answer {_firstValue} {_gameOperator} {_secondValue} = ");
    }

    internal void CalculateResult()
    {
        _result = _gameOperator switch
        {
            MultiplicationCharacter => _firstValue * _secondValue,
            DivisionCharacter => _firstValue / _secondValue,
            AdditionCharacter => _firstValue + _secondValue,
            SubtractionCharacter => _firstValue - _secondValue,
            _ => throw new NotImplementedException()
        };
    }

    internal bool IsDivision() => _gameOperator == DivisionCharacter;

    internal bool IsDivisionResultInteger() => _firstValue % _secondValue == 0;

    internal bool IsEnteredOptionABasicArithmenticOperation() => _gameOperator.Equals(MultiplicationCharacter) || _gameOperator.Equals(AdditionCharacter) || _gameOperator.Equals(SubtractionCharacter) || _gameOperator.Equals(DivisionCharacter);

    internal bool IsEnteredOptionForHistory() => char.ToLower(_gameOperator).Equals(char.ToLower(HistoryCharacter));

    internal bool IsEnteredOptionToExitGame() => char.ToLower(_gameOperator).Equals(char.ToLower(ExitCharacter));

    internal bool IsPlayerGuessAccurate() => _playerGuess == _result;

    internal void setOperandValues(int firstValue, int secondValue)
    {
        this._firstValue = firstValue;
        this._secondValue = secondValue;
    }

    internal void setPlayerGuess(int playerGuess)
    {
        this._playerGuess = playerGuess;
    }
}