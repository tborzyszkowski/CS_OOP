namespace Decimal.Tests;

public class DecimalInterestingTests
{
    [Fact]
    public void NegativeZeroWitchDot_IsNegative_ReturnsTrue()
    {
        // Arrange
        decimal longDecimalZero = -0.000m;

        bool longDecimalNegativeZero = decimal.IsNegative(longDecimalZero);

        // Assert
        Assert.True(longDecimalNegativeZero, "decimal.IsNegative(-0.000m) should return true?");
    }
}