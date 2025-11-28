using Decimal;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Console.WriteLine("=== Decimal Type Demonstration ===\n");

// 1. Valid Decimal Numbers
Console.WriteLine("1. VALID DECIMAL NUMBERS:");
Console.WriteLine($"   Valid Money: {DecimalExamples.ValidMoney1}");
Console.WriteLine($"   Valid Small Amount: {DecimalExamples.ValidMoney2}");
Console.WriteLine($"   Valid Large Amount: {DecimalExamples.ValidMoney3}");
Console.WriteLine($"   Valid Percentage: {DecimalExamples.ValidPercentage1}%");
Console.WriteLine($"   Very Small Number: {DecimalExamples.ValidSmallNumber}");
Console.WriteLine($"   Maximum Decimal: {DecimalExamples.ValidLargeNumber}\n");

// 2. Invalid/Problematic Decimal Numbers
Console.WriteLine("2. INVALID/PROBLEMATIC DECIMAL NUMBERS:");
Console.WriteLine($"   Money with too many decimals: {DecimalExamples.ProblematicMoney}");
Console.WriteLine($"   Is valid money? {DecimalHelper.IsValidMoneyAmount(DecimalExamples.ProblematicMoney)}");
Console.WriteLine($"   Negative money: {DecimalExamples.ProblematicNegativeMoney}");
Console.WriteLine($"   Is valid money? {DecimalHelper.IsValidMoneyAmount(DecimalExamples.ProblematicNegativeMoney)}");
Console.WriteLine($"   Invalid percentage (>100): {DecimalExamples.InvalidPercentage}%");
Console.WriteLine($"   Is valid percentage (0-100)? {DecimalHelper.IsValidPercentage(DecimalExamples.InvalidPercentage)}\n");

// 3. Decimal vs Double Precision
Console.WriteLine("3. DECIMAL vs DOUBLE PRECISION:");
var (decimalResult, doubleResult, areEqual) = DecimalVsOthers.ComparePrecision();
Console.WriteLine($"   Decimal: 0.1 + 0.2 = {decimalResult}");
Console.WriteLine($"   Double:  0.1 + 0.2 = {doubleResult}");
Console.WriteLine($"   Are they equal? {areEqual}");
Console.WriteLine($"   ✓ Decimal maintains exact precision!\n");

// 4. Financial Calculation Example
Console.WriteLine("4. FINANCIAL CALCULATION (RIGHT use of Decimal):");
decimal price = 19.99m;
decimal taxRate = 8.5m;
int quantity = 3;
decimal total = DecimalVsOthers.FinancialCalculation(price, taxRate, quantity);
Console.WriteLine($"   Price: ${price}");
Console.WriteLine($"   Quantity: {quantity}");
Console.WriteLine($"   Tax Rate: {taxRate}%");
Console.WriteLine($"   Total: ${total}\n");

// 5. Safe Operations
Console.WriteLine("5. SAFE OPERATIONS:");
decimal a = 10.5m;
decimal b = 20.3m;
Console.WriteLine($"   {a} + {b} = {DecimalHelper.SafeAdd(a, b)}");
Console.WriteLine($"   {a} * 2 = {DecimalHelper.SafeMultiply(a, 2m)}");
Console.WriteLine($"   10 / 2 = {DecimalHelper.SafeDivide(10m, 2m)}");

var divByZeroResult = DecimalHelper.SafeDivide(10m, 0m);
Console.WriteLine($"   10 / 0 = {(divByZeroResult.HasValue ? divByZeroResult.Value.ToString() : "null (division by zero)")}\n");

// 6. Overflow Examples
Console.WriteLine("6. OVERFLOW EXAMPLES:");
var overflowAdd = DecimalHelper.SafeAdd(decimal.MaxValue, 1m);
Console.WriteLine($"   Max value + 1 = {(overflowAdd.HasValue ? overflowAdd.Value.ToString() : "null (overflow)")}");

var overflowMult = DecimalHelper.SafeMultiply(decimal.MaxValue, 2m);
Console.WriteLine($"   Max value * 2 = {(overflowMult.HasValue ? overflowMult.Value.ToString() : "null (overflow)")}\n");

// 7. Validation Examples
Console.WriteLine("7. VALIDATION EXAMPLES:");
decimal validMoney = 123.45m;
decimal invalidMoney = 123.456m;
decimal validPercentage = 75m;
decimal invalidPercentage = 150m;

Console.WriteLine($"   ${validMoney} is valid money? {DecimalHelper.IsValidMoneyAmount(validMoney)}");
Console.WriteLine($"   ${invalidMoney} is valid money? {DecimalHelper.IsValidMoneyAmount(invalidMoney)}");
Console.WriteLine($"   {validPercentage}% is valid percentage (0-100)? {DecimalHelper.IsValidPercentage(validPercentage)}");
Console.WriteLine($"   {invalidPercentage}% is valid percentage (0-100)? {DecimalHelper.IsValidPercentage(invalidPercentage)}\n");

// 8. Key Takeaways
Console.WriteLine("=== KEY TAKEAWAYS ===");
Console.WriteLine("✓ RIGHT Numbers:");
Console.WriteLine("  - Money values: 19.99m, 0.01m, 100.50m");
Console.WriteLine("  - Always use 'm' suffix for decimal literals");
Console.WriteLine("  - Max 2 decimal places for currency");
Console.WriteLine("  - Non-negative for prices/amounts");
Console.WriteLine("  - Use decimal for financial calculations");
Console.WriteLine();
Console.WriteLine("✗ WRONG Numbers:");
Console.WriteLine("  - Money with >2 decimal places: 10.123m");
Console.WriteLine("  - Negative prices (context-dependent)");
Console.WriteLine("  - Percentages outside expected range");
Console.WriteLine("  - Using decimal for scientific calculations (use double)");
Console.WriteLine("  - Forgetting 'm' suffix: 123.45 (this is double, not decimal)");
Console.WriteLine();
Console.WriteLine("Range: ±1.0 × 10^-28 to ±7.9 × 10^28");
Console.WriteLine("Precision: 28-29 significant digits");
