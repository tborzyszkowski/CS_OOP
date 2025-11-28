# Decimal Type Usage Library

A comprehensive demonstration library showing proper usage of the C# `Decimal` type, including what constitutes "right" and "wrong" numbers in different contexts.

## Overview

This library demonstrates:
- Valid and invalid decimal numbers
- Proper decimal usage for financial calculations
- Decimal vs. Double precision differences
- Safe arithmetic operations with overflow protection
- Validation for money amounts and percentages

## Running the Demo

```bash
cd Decimal
dotnet run
```

## Running the Tests

```bash
cd Decimal.Tests
dotnet test
```

**Test Results:** All 65 unit tests pass ?

## Key Concepts

### When to Use Decimal

? **RIGHT Use Cases:**
- Financial calculations (money, prices, taxes)
- Monetary amounts requiring exact precision
- Percentages in financial context
- Any calculation where rounding errors are unacceptable

? **WRONG Use Cases:**
- Scientific calculations (use `double` instead)
- Graphics/game coordinates (use `float` or `double`)
- High-performance calculations where approximate precision is acceptable

### Valid Decimal Numbers

```csharp
// Financial values - ALWAYS use 'm' suffix
decimal price = 19.99m;           // ? Correct
decimal tax = 0.01m;              // ? One cent
decimal total = 999999.99m;       // ? Large amount

// Percentages
decimal interestRate = 5.5m;      // ? Valid percentage
decimal discount = 15.0m;         // ? Valid percentage

// Very small numbers (28-29 significant digits)
decimal precise = 0.0000000000000000000000000001m;  // ? Valid

// Range
decimal min = decimal.MinValue;   // -79,228,162,514,264,337,593,543,950,335
decimal max = decimal.MaxValue;   //  79,228,162,514,264,337,593,543,950,335
```

### Invalid/Problematic Decimal Numbers

```csharp
// Money with too many decimal places
decimal bad1 = 10.12345m;         // ? More than 2 decimal places for currency

// Negative money (context-dependent)
decimal bad2 = -100.50m;          // ? Invalid for prices/amounts

// Percentages outside expected range
decimal bad3 = 150m;              // ? Invalid if expecting 0-100

// Missing 'm' suffix - this is a double!
decimal bad4 = 10.50;             // ? Wrong! This requires casting from double
decimal good = 10.50m;            // ? Correct! Direct decimal literal
```

### Decimal vs. Double Precision

```csharp
// Decimal maintains exact precision
decimal d = 0.1m + 0.2m;  // = 0.3 (exact)

// Double has floating-point errors
double f = 0.1 + 0.2;     // = 0.30000000000000004 (approximate)
```

## Library Features

### DecimalHelper Class

Provides validation and safe operations:

```csharp
// Validation
bool isValid = DecimalHelper.IsValidMoneyAmount(123.45m);      // true
bool isValid2 = DecimalHelper.IsValidMoneyAmount(123.456m);    // false (too many decimals)
bool isPct = DecimalHelper.IsValidPercentage(75m);             // true
bool isPct2 = DecimalHelper.IsValidPercentage(150m);           // false (>100)

// Safe operations (returns null on overflow/error)
decimal? sum = DecimalHelper.SafeAdd(10m, 20m);                // 30
decimal? overflow = DecimalHelper.SafeAdd(decimal.MaxValue, 1m); // null
decimal? div = DecimalHelper.SafeDivide(10m, 0m);              // null
```

### DecimalExamples Class

Contains real-world examples:

```csharp
// Valid examples
DecimalExamples.ValidMoney1          // 123.45m
DecimalExamples.ValidPercentage1     // 15.5m
DecimalExamples.ValidSmallNumber     // 0.0000000000000000000000000001m

// Problematic examples
DecimalExamples.ProblematicMoney          // 10.123456m (too many decimals)
DecimalExamples.ProblematicNegativeMoney  // -10.50m (negative)
DecimalExamples.InvalidPercentage         // 150m (>100)
```

## Test Coverage

The test suite covers:

1. **DecimalHelperTests** - Validation and safe operations
   - Valid/invalid money amounts
   - Valid/invalid percentages
   - Overflow protection
   - Division by zero handling
   - Precision rounding

2. **DecimalExamplesTests** - Real-world scenarios
   - Valid number examples
   - Invalid number examples
   - Runtime overflow cases

3. **DecimalVsOthersTests** - Comparison with other types
   - Decimal vs. Double precision
   - Financial calculations
   - Scientific calculations

4. **RightAndWrongNumbersTests** - What makes numbers "right" or "wrong"
   - Context-specific validation
   - Proper literal syntax
   - Use case appropriateness

## Best Practices

1. **Always use 'm' suffix** for decimal literals:
   ```csharp
   decimal good = 10.50m;    // ?
   decimal bad = (decimal)10.50;  // ? (requires cast from double)
   ```

2. **Currency should have max 2 decimal places**:
   ```csharp
   decimal price = 19.99m;   // ?
   decimal wrong = 19.999m;  // ?
   ```

3. **Validate input** for business rules:
   ```csharp
   if (!DecimalHelper.IsValidMoneyAmount(value))
       throw new ArgumentException("Invalid money amount");
   ```

4. **Use safe operations** when overflow is possible:
   ```csharp
   var result = DecimalHelper.SafeAdd(a, b);
   if (!result.HasValue)
       // Handle overflow
   ```

5. **Choose the right numeric type**:
   - `decimal` ? Financial/monetary calculations
   - `double` ? Scientific/engineering calculations
   - `float` ? Graphics, games, low-precision needs

## Decimal Characteristics

- **Range:** 1.0  10??? to 7.9228162514264337593543950335  10??
- **Precision:** 28-29 significant digits
- **Storage:** 128 bits (16 bytes)
- **Base:** Base-10 (unlike float/double which are base-2)
- **Performance:** Slower than double, but exact for decimal fractions

## Project Structure

```
Decimal/
??? Program.cs          # Demo application
??? DecimalHelper.cs    # Helper methods and examples
??? Decimal.csproj

Decimal.Tests/
??? DecimalTests.cs     # Comprehensive unit tests (65 tests)
??? Decimal.Tests.csproj
```

## License

Educational demonstration project.
