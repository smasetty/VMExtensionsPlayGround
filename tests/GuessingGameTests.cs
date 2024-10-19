using VMExtensionsPlayground;

namespace tests;
public class GuessingGameTests
{
    [Fact]
    public void Constructor_SetsAvailableGuessesCorrectly()
    {
        // Arrange
        const int availableGuesses = 5;

        // Act
        var game = new GuessingGame(availableGuesses);

        // Assert
        Assert.False(game.IsGameOver());
    }

    [Fact]
    public void MakeAGuess_ReturnsCorrect_WhenGuessedNumberIsCorrect()
    {
        // Arrange
        const int numberOfGuesses = 5;

        var game = new GuessingGame(numberOfGuesses);

        // Use reflection to set the correct number directly for testing purposes
        typeof(GuessingGame)
            .GetField("_numberToGuess", 
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            ?.SetValue(game, 5); // Set correct number as 5

        // Act
        var result = game.MakeAGuess(5);

        // Assert
        Assert.Equal(PlayerGuessResult.Correct, result);
    }

    [Fact]
    public void MakeAGuess_ReturnsIncorrect_WhenGuessedNumberIsIncorrect()
    {
        // Arrange
        const int numberOfGuesses = 5;

        var game = new GuessingGame(numberOfGuesses);

        // Use reflection to set an incorrect number directly for testing purposes
        typeof(GuessingGame)
            .GetField("_numberToGuess", 
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            ?.SetValue(game, 5); // Set correct number as 5

        // Act
        var result = game.MakeAGuess(3);

        // Assert
        Assert.Equal(PlayerGuessResult.Incorrect, result);
    }

    [Fact]
    public void MakeAGuess_DecreasesAvailableGuesses()
    {
        // Arrange
        const int numberOfGuesses = 5;

        var game = new GuessingGame(numberOfGuesses);

        // Use reflection to set an incorrect number directly for testing purposes
        typeof(GuessingGame)
            .GetField("_numberToGuess", 
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            ?.SetValue(game, 5); // Set correct number as 5

        // Act
        game.MakeAGuess(3); // First guess
        game.MakeAGuess(7); // Second guess

        // Assert
        Assert.False(game.IsGameOver()); // Guesses should be remaining
    }

    [Fact]
    public void MakeAGuess_ReturnsGameOver_WhenNoGuessesLeft()
    {
        // Arrange
        const int numberOfGuesses = 1; // Only 1 guess allowed

        var game = new GuessingGame(numberOfGuesses);

        // Use reflection to set an incorrect number directly for testing purposes
        typeof(GuessingGame)
            .GetField("_numberToGuess",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            ?.SetValue(game, 5); // Set correct number as 5

        // Act
        game.MakeAGuess(3); // Use the only available guess

        var result = game.MakeAGuess(5); // Try guessing again

        // Assert
        Assert.Equal(PlayerGuessResult.GameOver, result);
        Assert.True(game.IsGameOver());
    }
}
