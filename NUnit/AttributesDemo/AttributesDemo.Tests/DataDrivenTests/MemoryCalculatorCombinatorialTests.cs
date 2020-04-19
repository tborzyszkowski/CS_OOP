using NUnit.Framework;

namespace AttributesDemo.Tests.DataDrivenTests {
	[TestFixture]
	public class MemoryCalculatorCombinatorialTests {
		[Test]
		public void ShouldAddAndDivide(
			[Values(10, 20, 30)] int numToAdd,
			[Values(2, 1, 10)]   int numToDivideBy) {
			var sut = new MemoryCalculator();

			sut.Add(numToAdd);

			sut.Divide(numToDivideBy);
		}
	}
}
