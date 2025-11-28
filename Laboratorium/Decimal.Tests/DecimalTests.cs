using Xunit;

namespace Decimal.Tests;

/// <summary>
/// Tests demonstrating valid and invalid decimal usage
/// </summary>
public class DecimalHelperTests
{
    [Fact]
    public void IsValidDecimal_WithNormalValue_ReturnsTrue()
    {
        // Arrange
        decimal value = 123.45m;
        
        // Act
        bool result = DecimalHelper.IsValidDecimal(value);
        
        // Assert
        Assert.True(result);
    }
    
    [Fact]
    public void IsValidDecimal_WithMaxValue_ReturnsTrue()
    {
        // Arrange
        decimal value = decimal.MaxValue;
        
        // Act
        bool result = DecimalHelper.IsValidDecimal(value);
        
        // Assert
        Assert.True(result);
    }
    
    [Fact]
    public void IsValidDecimal_WithMinValue_ReturnsTrue()
    {
        // Arrange
        decimal value = decimal.MinValue;
        
        // Act
        bool result = DecimalHelper.IsValidDecimal(value);
        
        // Assert
        Assert.True(result);
    }
    
    [Theory]
    [InlineData(10.50)]  // Valid money amount
    [InlineData(0.01)]   // One cent
    [InlineData(100.00)] // Whole dollar amount
    public void IsValidMoneyAmount_WithValidMoney_ReturnsTrue(double amount)
    {
        // Arrange
        decimal value = (decimal)amount;
        
        // Act
        bool result = DecimalHelper.IsValidMoneyAmount(value);
        
        // Assert
        Assert.True(result);
    }
    
    [Theory]
    [InlineData(-10.50)]   // Negative amount
    [InlineData(-0.01)]    // Negative cent
    public void IsValidMoneyAmount_WithNegativeAmount_ReturnsFalse(double amount)
    {
        // Arrange
        decimal value = (decimal)amount;
        
        // Act
        bool result = DecimalHelper.IsValidMoneyAmount(value);
        
        // Assert
        Assert.False(result);
    }
    
    [Fact]
    public void IsValidMoneyAmount_WithTooManyDecimalPlaces_ReturnsFalse()
    {
        // Arrange - Money should have max 2 decimal places
        decimal value = 10.123m;
        
        // Act
        bool result = DecimalHelper.IsValidMoneyAmount(value);
        
        // Assert
        Assert.False(result);
    }
    
    [Theory]
    [InlineData(0)]      // Minimum valid percentage
    [InlineData(50.5)]   // Mid-range percentage
    [InlineData(100)]    // Maximum valid percentage
    [InlineData(99.99)]  // High precision percentage
    public void IsValidPercentage_WithValidPercentage_ReturnsTrue(double percentage)
    {
        // Arrange
        decimal value = (decimal)percentage;
        
        // Act
        bool result = DecimalHelper.IsValidPercentage(value);
        
        // Assert
        Assert.True(result);
    }
    
    [Theory]
    [InlineData(-1)]     // Below zero
    [InlineData(-50)]    // Negative
    [InlineData(101)]    // Above 100
    [InlineData(150.5)]  // Well above 100
    public void IsValidPercentage_WithInvalidPercentage_ReturnsFalse(double percentage)
    {
        // Arrange
        decimal value = (decimal)percentage;
        
        // Act
        bool result = DecimalHelper.IsValidPercentage(value);
        
        // Assert
        Assert.False(result);
    }
    
    [Fact]
    public void SafeAdd_WithNormalValues_ReturnsSum()
    {
        // Arrange
        decimal a = 10.5m;
        decimal b = 20.3m;
        
        // Act
        decimal? result = DecimalHelper.SafeAdd(a, b);
        
        // Assert
        Assert.NotNull(result);
        Assert.Equal(30.8m, result.Value);
    }
    
    [Fact]
    public void SafeAdd_WithOverflow_ReturnsNull()
    {
        // Arrange - Adding to max value causes overflow
        decimal a = decimal.MaxValue;
        decimal b = 1m;
        
        // Act
        decimal? result = DecimalHelper.SafeAdd(a, b);
        
        // Assert
        Assert.Null(result);
    }
    
    [Fact]
    public void SafeMultiply_WithNormalValues_ReturnsProduct()
    {
        // Arrange
        decimal a = 10.5m;
        decimal b = 2m;
        
        // Act
        decimal? result = DecimalHelper.SafeMultiply(a, b);
        
        // Assert
        Assert.NotNull(result);
        Assert.Equal(21m, result.Value);
    }
    
    [Fact]
    public void SafeMultiply_WithOverflow_ReturnsNull()
    {
        // Arrange - Multiplying max value causes overflow
        decimal a = decimal.MaxValue;
        decimal b = 2m;
        
        // Act
        decimal? result = DecimalHelper.SafeMultiply(a, b);
        
        // Assert
        Assert.Null(result);
    }
    
    [Fact]
    public void SafeDivide_WithNormalValues_ReturnsQuotient()
    {
        // Arrange
        decimal numerator = 10m;
        decimal denominator = 2m;
        
        // Act
        decimal? result = DecimalHelper.SafeDivide(numerator, denominator);
        
        // Assert
        Assert.NotNull(result);
        Assert.Equal(5m, result.Value);
    }
    
    [Fact]
    public void SafeDivide_WithZeroDenominator_ReturnsNull()
    {
        // Arrange
        decimal numerator = 10m;
        decimal denominator = 0m;
        
        // Act
        decimal? result = DecimalHelper.SafeDivide(numerator, denominator);
        
        // Assert
        Assert.Null(result);
    }
    
    [Theory]
    [InlineData(10.12345, 2, 10.12)]
    [InlineData(10.12345, 3, 10.123)]
    [InlineData(10.19999, 2, 10.20)]
    public void CalculatePreciseValue_RoundsCorrectly(double value, int places, double expected)
    {
        // Arrange
        decimal decimalValue = (decimal)value;
        decimal expectedValue = (decimal)expected;
        
        // Act
        decimal result = DecimalHelper.CalculatePreciseValue(decimalValue, places);
        
        // Assert
        Assert.Equal(expectedValue, result);
    }
    
    [Fact]
    public void HasExcessDecimalPlaces_WithExcessPlaces_ReturnsTrue()
    {
        // Arrange - 3 decimal places, max allowed is 2
        decimal value = 10.123m;
        int maxPlaces = 2;
        
        // Act
        bool result = DecimalHelper.HasExcessDecimalPlaces(value, maxPlaces);
        
        // Assert
        Assert.True(result);
    }
    
    [Fact]
    public void HasExcessDecimalPlaces_WithinLimit_ReturnsFalse()
    {
        // Arrange - 2 decimal places, max allowed is 2
        decimal value = 10.12m;
        int maxPlaces = 2;
        
        // Act
        bool result = DecimalHelper.HasExcessDecimalPlaces(value, maxPlaces);
        
        // Assert
        Assert.False(result);
    }
    
    [Fact]
    public void NegativeZero_IsValid_AndEqualToPositiveZero()
    {
        // Arrange
        decimal negativeZero = -0.000m;
        decimal positiveZero = 0.000m;
        decimal zero = 0m;
        
        // Act
        bool isValid = DecimalHelper.IsValidDecimal(negativeZero);
        bool equalsPositiveZero = (negativeZero == positiveZero);
        bool equalsZero = (negativeZero == zero);
        
        // Assert
        Assert.True(isValid, "Negative zero should be a valid decimal");
        Assert.True(equalsPositiveZero, "Negative zero should equal positive zero");
        Assert.True(equalsZero, "Negative zero should equal zero");
        Assert.Equal(0m, negativeZero);
    }
    
    [Fact]
    public void NegativeZero_IsNegative_ReturnsFalse()
    {
        // Arrange
        decimal negativeZero = -0.000m;
        decimal positiveZero = 0.000m;
        decimal actualNegative = -0.001m;
        
        // Act
        bool negativeZeroIsNegative = decimal.IsNegative(negativeZero);
        bool positiveZeroIsNegative = decimal.IsNegative(positiveZero);
        bool actualNegativeIsNegative = decimal.IsNegative(actualNegative);
        
        // Assert
        Assert.False(negativeZeroIsNegative, "decimal.IsNegative(-0.000m) should return false");
        Assert.False(positiveZeroIsNegative, "decimal.IsNegative(0.000m) should return false");
        Assert.True(actualNegativeIsNegative, "decimal.IsNegative(-0.001m) should return true");
    }
}

public class DecimalExamplesTests
{
    [Fact]
    public void ValidMoney_HasCorrectDecimalPlaces()
    {
        // Assert - All valid money examples should have 2 or fewer decimal places
        Assert.True(DecimalHelper.IsValidMoneyAmount(DecimalExamples.ValidMoney1));
        Assert.True(DecimalHelper.IsValidMoneyAmount(DecimalExamples.ValidMoney2));
        Assert.True(DecimalHelper.IsValidMoneyAmount(DecimalExamples.ValidMoney3));
    }
    
    [Fact]
    public void ValidPercentages_AreInValidRange()
    {
        // Assert - These percentages are valid numbers, though context matters
        Assert.True(DecimalExamples.ValidPercentage1 >= 0);
        Assert.True(DecimalExamples.ValidPercentage2 >= 0);
        Assert.True(DecimalExamples.ValidPercentage3 >= 0);
    }
    
    [Fact]
    public void ProblematicMoney_HasTooManyDecimalPlaces()
    {
        // Assert - This is problematic for currency
        Assert.False(DecimalHelper.IsValidMoneyAmount(DecimalExamples.ProblematicMoney));
    }
    
    [Fact]
    public void ProblematicNegativeMoney_IsNegative()
    {
        // Assert - Negative money is invalid for prices/amounts
        Assert.False(DecimalHelper.IsValidMoneyAmount(DecimalExamples.ProblematicNegativeMoney));
    }
    
    [Fact]
    public void InvalidPercentage_IsOutOfRange()
    {
        // Assert - 150% is invalid if expecting 0-100 range
        Assert.False(DecimalHelper.IsValidPercentage(DecimalExamples.InvalidPercentage));
    }
    
    [Fact]
    public void RuntimeProblems_OverflowAddition_ReturnsNull()
    {
        // Act
        var result = DecimalExamples.RuntimeProblems.OverflowAddition();
        
        // Assert - Overflow should be caught and return null
        Assert.Null(result);
    }
    
    [Fact]
    public void RuntimeProblems_OverflowMultiplication_ReturnsNull()
    {
        // Act
        var result = DecimalExamples.RuntimeProblems.OverflowMultiplication();
        
        // Assert - Overflow should be caught and return null
        Assert.Null(result);
    }
    
    [Fact]
    public void RuntimeProblems_DivisionByZero_ReturnsNull()
    {
        // Act
        var result = DecimalExamples.RuntimeProblems.DivisionByZero();
        
        // Assert - Division by zero should be caught and return null
        Assert.Null(result);
    }
    
    [Fact]
    public void ValidSmallNumber_IsWithinDecimalRange()
    {
        // Assert - Decimal can represent very small numbers
        Assert.True(DecimalExamples.ValidSmallNumber > 0);
        Assert.Equal(0.0000000000000000000000000001m, DecimalExamples.ValidSmallNumber);
    }
    
    [Fact]
    public void ValidLargeNumber_IsDecimalMaxValue()
    {
        // Assert - This is the maximum decimal value
        Assert.Equal(decimal.MaxValue, DecimalExamples.ValidLargeNumber);
    }
}

public class DecimalVsOthersTests
{
    [Fact]
    public void ComparePrecision_DecimalIsExact_DoubleIsNot()
    {
        // Act
        var (decimalResult, doubleResult, areEqual) = DecimalVsOthers.ComparePrecision();
        
        // Assert
        Assert.Equal(0.3m, decimalResult);  // Decimal is exact
        Assert.NotEqual(0.3, doubleResult); // Double has floating point error
        Assert.False(areEqual);              // They are not equal
    }
    
    [Fact]
    public void FinancialCalculation_UsesDecimal_ForPrecision()
    {
        // Arrange
        decimal price = 19.99m;
        decimal taxRate = 8.5m;  // 8.5% tax
        int quantity = 3;
        
        // Act
        decimal total = DecimalVsOthers.FinancialCalculation(price, taxRate, quantity);
        
        // Assert
        // 19.99 * 3 = 59.97
        // 59.97 * 0.085 = 5.09745
        // 59.97 + 5.09745 = 65.06745, but we should get exact calculation
        Assert.Equal(65.06745m, total);
    }
    
    [Fact]
    public void ScientificCalculation_UsesDouble_ForPerformance()
    {
        // Arrange
        double mass = 1.0; // 1 kg
        
        // Act
        double energy = DecimalVsOthers.ScientificCalculation(mass, 0);
        
        // Assert - Scientific calculations use double for speed
        Assert.True(energy > 0);
    }
}

/// <summary>
/// Tests demonstrating what makes a "right" vs "wrong" decimal number
/// </summary>
public class RightAndWrongNumbersTests
{
    [Theory]
    [InlineData(0)]
    [InlineData(0.01)]
    [InlineData(1.5)]
    [InlineData(100.50)]
    [InlineData(9999999.99)]
    public void RightNumbers_ForMoney_HaveMaxTwoDecimalPlaces(double value)
    {
        // Arrange
        decimal money = (decimal)value;
        
        // Assert - These are RIGHT for monetary values
        Assert.True(DecimalHelper.IsValidMoneyAmount(money), 
            $"{money} should be valid money (non-negative, max 2 decimal places)");
    }
    
    [Theory]
    [InlineData(-10.50)]      // Negative
    [InlineData(10.123)]      // Too many decimal places
    [InlineData(10.12345)]    // Way too many decimal places
    public void WrongNumbers_ForMoney_FailValidation(double value)
    {
        // Arrange
        decimal money = (decimal)value;
        
        // Assert - These are WRONG for monetary values
        Assert.False(DecimalHelper.IsValidMoneyAmount(money),
            $"{money} should be invalid money");
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(25)]
    [InlineData(50.5)]
    [InlineData(99.99)]
    [InlineData(100)]
    public void RightNumbers_ForPercentage_AreBetween0And100(double value)
    {
        // Arrange
        decimal percentage = (decimal)value;
        
        // Assert - These are RIGHT for percentages (0-100 range)
        Assert.True(DecimalHelper.IsValidPercentage(percentage),
            $"{percentage}% should be valid percentage");
    }
    
    [Theory]
    [InlineData(-1)]
    [InlineData(-50)]
    [InlineData(101)]
    [InlineData(200)]
    public void WrongNumbers_ForPercentage_AreOutsideRange(double value)
    {
        // Arrange
        decimal percentage = (decimal)value;
        
        // Assert - These are WRONG for percentages (outside 0-100)
        Assert.False(DecimalHelper.IsValidPercentage(percentage),
            $"{percentage}% should be invalid percentage");
    }
    
    [Fact]
    public void RightNumbers_DecimalLiterals_UseMSuffix()
    {
        // These are RIGHT - using 'm' suffix for decimal literals
        decimal right1 = 123.45m;
        decimal right2 = 0.01m;
        decimal right3 = 100m;
        
        // Assert
        Assert.Equal(123.45m, right1);
        Assert.Equal(0.01m, right2);
        Assert.Equal(100m, right3);
    }
    
    [Fact]
    public void WrongNumbers_WithoutMSuffix_RequiresCast()
    {
        // These compile but require cast - less efficient and clear
        decimal wrong1 = (decimal)123.45;  // Double to decimal cast
        decimal wrong2 = (decimal)0.01;    // Double to decimal cast
        
        // Better to use 'm' suffix directly
        decimal right1 = 123.45m;
        decimal right2 = 0.01m;
        
        // Assert - Values are same but declaration matters for clarity
        Assert.Equal(wrong1, right1);
        Assert.Equal(wrong2, right2);
    }
    
    [Fact]
    public void RightUseCase_FinancialCalculations()
    {
        // RIGHT: Use decimal for money
        decimal price = 19.99m;
        decimal quantity = 3m;
        decimal total = price * quantity;
        
        Assert.Equal(59.97m, total);  // Exact precision maintained
    }
    
    [Fact]
    public void WrongUseCase_ScientificCalculations()
    {
        // WRONG: Don't use decimal for scientific/engineering calculations
        // Decimal is slower and scientific calculations don't need exact decimal precision
        
        // Better to use double for scientific:
        double mass = 1.0;
        double speedOfLight = 299792458.0;
        double energy = mass * Math.Pow(speedOfLight, 2);
        
        Assert.True(energy > 0);
    }
    
    [Fact]
    public void DecimalRange_MinAndMaxValues()
    {
        // RIGHT: These are within decimal range
        decimal min = decimal.MinValue;  // -79,228,162,514,264,337,593,543,950,335
        decimal max = decimal.MaxValue;  //  79,228,162,514,264,337,593,543,950,335
        decimal zero = 0m;
        
        Assert.Equal(-79228162514264337593543950335m, min);
        Assert.Equal(79228162514264337593543950335m, max);
        Assert.Equal(0m, zero);
    }
    
    [Fact]
    public void DecimalPrecision_28_29SignificantDigits()
    {
        // Decimal has 28-29 significant digits of precision
        decimal precise = 1.0000000000000000000000000001m;  // 28 digits after decimal
        
        Assert.NotEqual(1m, precise);
        Assert.True(precise > 1m);
    }
}
