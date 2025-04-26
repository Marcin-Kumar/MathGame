namespace MathGame
{
    internal class Program
    {
        private const char MultiplicationCharacter = '*';
        private const char DivisionCharacter = '/';
        private const char AdditionCharacter = '+';
        private const char SubtractionCharacter = '-';
        private const char HistoryCharacter = 'h';

        private static int s_playerGuess;
        private static int s_operationResult;
        private static List<string> s_gameRecord = new List<string>();
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello, Welcome to the Math Game\n");
            DisplayMenu();
            char menuOption = Console.ReadKey().KeyChar;
            if (IsEnteredOptionABasicArithmenticOperation(menuOption))
            {
                Random randomValueGenerator = new Random();
                int firstValue = randomValueGenerator.Next(101);
                int secondValue = randomValueGenerator.Next(101);
                switch (menuOption)
                {
                    case DivisionCharacter:
                        if (firstValue % secondValue == 0)
                        {
                            ExecuteGame(menuOption, firstValue, secondValue);

                        }
                        break;
                    case MultiplicationCharacter:
                    case AdditionCharacter:
                    case SubtractionCharacter:
                        ExecuteGame(menuOption, firstValue, secondValue);
                        break;
                }
                string gameResult = IsPlayerGuessAccurate() ? "Correct" : "Wrong";
                s_gameRecord.Add(gameResult);
                Console.WriteLine(gameResult);
            }
            else if (IsEnteredOptionForHistory(menuOption))
            {
                Console.WriteLine($"Game History");
                foreach (var item in s_gameRecord)
                {
                    Console.WriteLine(item);
                }
            }
        }

        private static void ExecuteGame(char menuOption, int firstValue, int secondValue)
        {
            bool isPlayerGuessInteger;
            do
            {
                DisplayOperation(firstValue, secondValue, menuOption);
                isPlayerGuessInteger = int.TryParse(Console.ReadLine(), out s_playerGuess);

            } while (!isPlayerGuessInteger);
            s_operationResult = ExecuteOperation(firstValue, secondValue, menuOption);
        }

        private static bool IsPlayerGuessAccurate() => s_playerGuess == s_operationResult;

        private static void DisplayMenu()
        {
            Console.WriteLine("You can test your arithmetic skills using the 4 basic artihmetic operations");
            Console.WriteLine("Please find the possible operations you can choose.\n");
            Console.WriteLine("\t* for Multiplication");
            Console.WriteLine("\t/ for Division");
            Console.WriteLine("\t- for Subtraction");
            Console.WriteLine("\t+ for Addition");
            Console.WriteLine("\tH or h to view game history\n");
            Console.WriteLine("Please enter an option to start the game\n");
        }

        private static bool IsEnteredOptionABasicArithmenticOperation(char menuOption) => menuOption.Equals(MultiplicationCharacter) || menuOption.Equals(AdditionCharacter) || menuOption.Equals(SubtractionCharacter) || menuOption.Equals(DivisionCharacter);

        private static bool IsEnteredOptionForHistory(char menuOption) => char.ToLower(menuOption).Equals(char.ToLower(HistoryCharacter));

        private static void DisplayOperation(int firstValue, int secondValue, char operation)
        {
            Console.WriteLine("The input should be a valid whole number");
            Console.WriteLine($"Guess the answer {firstValue} {operation} {secondValue} = ");
        }

        private static int ExecuteOperation(int firstValue, int secondValue, char operation) => operation switch
        {
            MultiplicationCharacter => firstValue * secondValue,
            DivisionCharacter => firstValue / secondValue,
            AdditionCharacter => firstValue + secondValue,
            SubtractionCharacter => firstValue - secondValue,
            _ => throw new NotImplementedException()
        };
        
    }
}