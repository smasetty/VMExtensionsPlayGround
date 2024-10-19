namespace VMExtensionsPlayground
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter Your Name: ");
            var name = Console.ReadLine();
            var currentData = DateTime.Now;

            Console.WriteLine($"{Environment.NewLine} Hello, {name}! at {currentData:D} and time {currentData:t}");

            Console.WriteLine($"{Environment.NewLine} Press any key to play a guessing game");
            Console.ReadKey();

            PlayGuessingGame();

            return;
        }
        private static void PlayGuessingGame()
        {
            const int numberOfGuesses = 3;
            GuessingGame game = new(numberOfGuesses);

            Console.WriteLine($"{Environment.NewLine} to the Number Guessing Game");
            Console.WriteLine($"{Environment.NewLine} I have selected a number between 1 to 10, try to guess it.");
            Console.WriteLine($"{Environment.NewLine} You will be given {numberOfGuesses} chances to guess.");

            while (!game.IsGameOver())
            {
                Console.WriteLine($"{Environment.NewLine} Enter your guess: ");
                int guessedNumber;
                try
                {
                     guessedNumber = int.Parse(Console.ReadLine() ?? string.Empty);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Invalid Input: {e.Message}");
                    continue;
                }

                var result = game.MakeAGuess(guessedNumber);

                switch (result)
                {
                    case PlayerGuessResult.Correct:
                        Console.WriteLine($"{Environment.NewLine}!!! You guessed the number correctly.");
                        return;
                    case PlayerGuessResult.Incorrect:
                        Console.WriteLine($"{Environment.NewLine} Incorrect guess. Try again.");
                        break;
                    case PlayerGuessResult.GameOver:
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            Console.WriteLine($"{Environment.NewLine} Game Over! You have exhausted all your guesses.");
        }
    }
}
