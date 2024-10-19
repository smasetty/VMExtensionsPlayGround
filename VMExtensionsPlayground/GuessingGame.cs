namespace VMExtensionsPlayground;

public class GuessingGame
{
    private readonly int _numberToGuess;
    private int AvailableGuesses { get; set; }

    public GuessingGame(int numberOfAvailableGuesses)
    {
        Random random = new();
        _numberToGuess = random.Next(1, 11);
        AvailableGuesses = numberOfAvailableGuesses;
    }

    public PlayerGuessResult MakeAGuess(int guessedNumber)
    {
        if (IsGameOver())
        {
            return PlayerGuessResult.GameOver;
        }

        DecreaseAvailableGuesses();

        return IsCorrectGuess(guessedNumber) ?
            PlayerGuessResult.Correct : PlayerGuessResult.Incorrect;
    }

    private void DecreaseAvailableGuesses()
    {
        AvailableGuesses--;
    }
    public bool IsGameOver()
    {
        return AvailableGuesses == 0;
    }

    private bool IsCorrectGuess(int guessedNumber)
    {
        return guessedNumber == _numberToGuess;
    }
}
