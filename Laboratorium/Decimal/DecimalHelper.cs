namespace Decimal;

/// <summary>
/// Helper class demonstrating proper Decimal type usage and validation
/// </summary>
public class DecimalHelper
{
    // Decimal range: ±1.0 × 10^-28 to ±7.9228162514264337593543950335 × 10^28
    public const decimal MinValue = decimal.MinValue; // -79,228,162,514,264,337,593,543,950,335
    public const decimal MaxValue = decimal.MaxValue; //  79,228,162,514,264,337,593,543,950,335
    
    /// <summary>
    /// Validates if a decimal is within acceptable range
    /// </summary>
    public static bool IsValidDecimal(decimal value)
    {
        return value >= MinValue && value <= MaxValue;
    }
    
    /// <summary>
    /// Validates if a decimal represents a valid monetary amount (non-negative, max 2 decimal places)
    /// </summary>
    public static bool IsValidMoneyAmount(decimal value)
    {
        if (value < 0) return false;
        
        // Check if it has more than 2 decimal places
        decimal rounded = Math.Round(value, 2);
        return rounded == value;
    }
    
    /// <summary>
    /// Validates if a decimal represents a valid percentage (0-100)
    /// </summary>
    public static bool IsValidPercentage(decimal value)
    {
        return value >= 0 && value <= 100;
    }
    
    /// <summary>
    /// Safely adds two decimals, returns null if overflow would occur
    /// </summary>
    public static decimal? SafeAdd(decimal a, decimal b)
    {
        try
        {
            return checked(a + b);
        }
        catch (OverflowException)
        {
            return null;
        }
    }
    
    /// <summary>
    /// Safely multiplies two decimals, returns null if overflow would occur
    /// </summary>
    public static decimal? SafeMultiply(decimal a, decimal b)
    {
        try
        {
            return checked(a * b);
        }
        catch (OverflowException)
        {
            return null;
        }
    }
    
    /// <summary>
    /// Divides two decimals safely, returns null if division by zero
    /// </summary>
    public static decimal? SafeDivide(decimal numerator, decimal denominator)
    {
        if (denominator == 0)
            return null;
            
        return numerator / denominator;
    }
    
    /// <summary>
    /// Demonstrates precision: Decimal maintains exact precision for decimal fractions
    /// </summary>
    public static decimal CalculatePreciseValue(decimal value, int decimalPlaces)
    {
        return Math.Round(value, decimalPlaces);
    }
    
    /// <summary>
    /// Checks if a value has more decimal places than allowed
    /// </summary>
    public static bool HasExcessDecimalPlaces(decimal value, int maxDecimalPlaces)
    {
        decimal rounded = Math.Round(value, maxDecimalPlaces);
        return rounded != value;
    }
}

/// <summary>
/// Examples of valid and invalid decimal numbers
/// </summary>
public static class DecimalExamples
{
    // VALID DECIMALS - These are appropriate uses
    
    // Financial/Money values - ideal use case for decimal
    public static readonly decimal ValidMoney1 = 123.45m;
    public static readonly decimal ValidMoney2 = 0.01m; // One cent
    public static readonly decimal ValidMoney3 = 999999.99m;
    
    // Percentages with precision
    public static readonly decimal ValidPercentage1 = 15.5m;
    public static readonly decimal ValidPercentage2 = 0.01m;
    public static readonly decimal ValidPercentage3 = 99.999m;
    
    // Very small precise numbers
    public static readonly decimal ValidSmallNumber = 0.0000000000000000000000000001m; // 10^-28
    
    // Very large numbers within decimal range
    public static readonly decimal ValidLargeNumber = 79228162514264337593543950335m; // Max value
    
    // Negative values
    public static readonly decimal ValidNegative = -123.45m;
    
    // Zero
    public static readonly decimal ValidZero = 0m;
    
    // INVALID OR PROBLEMATIC DECIMALS
    
    // Money with too many decimal places (not exactly invalid, but problematic for currency)
    public static readonly decimal ProblematicMoney = 10.123456m; // More than 2 decimal places
    
    // Negative money (context-dependent, often invalid for prices)
    public static readonly decimal ProblematicNegativeMoney = -10.50m;
    
    // Invalid percentages (over 100)
    public static readonly decimal InvalidPercentage = 150m; // Context: if expecting 0-100
    
    // Edge case: trying to represent values beyond decimal range would cause compilation error
    // public static readonly decimal InvalidTooBig = 79228162514264337593543950336m; // Won't compile!
    
    /// <summary>
    /// Creates examples that would overflow at runtime
    /// </summary>
    public static class RuntimeProblems
    {
        public static decimal? OverflowAddition()
        {
            try
            {
                decimal max = decimal.MaxValue;
                return checked(max + 1m);
            }
            catch (OverflowException)
            {
                return null;
            }
        }
        
        public static decimal? OverflowMultiplication()
        {
            try
            {
                decimal max = decimal.MaxValue;
                return checked(max * 2m);
            }
            catch (OverflowException)
            {
                return null;
            }
        }
        
        public static decimal? DivisionByZero()
        {
            try
            {
                decimal zero = 0m;
                return 100m / zero;
            }
            catch (DivideByZeroException)
            {
                return null;
            }
        }
    }
}

/// <summary>
/// Decimal vs Double vs Float comparison
/// </summary>
public static class DecimalVsOthers
{
    /// <summary>
    /// Demonstrates precision difference between decimal and double
    /// </summary>
    public static (decimal decimalResult, double doubleResult, bool areEqual) ComparePrecision()
    {
        decimal decimalValue = 0.1m + 0.2m;  // Exact: 0.3
        double doubleValue = 0.1 + 0.2;       // Approximate: 0.30000000000000004
        
        return (decimalValue, doubleValue, (double)decimalValue == doubleValue);
    }
    
    /// <summary>
    /// Shows when to use decimal: financial calculations
    /// </summary>
    public static decimal FinancialCalculation(decimal price, decimal taxRate, int quantity)
    {
        decimal subtotal = price * quantity;
        decimal tax = subtotal * (taxRate / 100m);
        return subtotal + tax;
    }
    
    /// <summary>
    /// Shows when NOT to use decimal: scientific calculations (use double)
    /// Double is faster and scientific precision doesn't need exact decimal representation
    /// </summary>
    public static double ScientificCalculation(double mass, double velocity)
    {
        // E = mc^2 type calculations - use double, not decimal
        const double speedOfLight = 299792458.0;
        return mass * Math.Pow(speedOfLight, 2);
    }
}
