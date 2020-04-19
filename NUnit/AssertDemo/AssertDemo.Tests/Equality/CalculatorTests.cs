using NUnit.Framework;

namespace AssertDemo.Tests.Equality {
	[TestFixture]
	public class CalculatorTests {
		[Test]
		public void ShouldAddInts() {
			var sut = new Calculator();

			var result = sut.AddInts(1, 2);

			Assert.That(result, Is.EqualTo(3));
		}


		[Test]
		public void ShouldAddDoubles() {
			var sut = new Calculator();

			var result = sut.AddDoubles(1.1, 2.2);

			Assert.That(result, Is.EqualTo(3.3));
		}


		[Test]
		public void ShouldAddDoubles_WithTolerance() {
			var sut = new Calculator();

			var result = sut.AddDoubles(1.1, 2.2);

			Assert.That(result, Is.EqualTo(3.3).Within(0.00001));
		}


		[Test]
		public void ShouldAddDoubles_WithPercentTolerance() {
			var sut = new Calculator();

			var result = sut.AddDoubles(50, 50);

			Assert.That(result, Is.EqualTo(101).Within(1).Percent);
		}


		[Test]
		public void ShouldAddDoubles_WithBadTolerance() {
			var sut = new Calculator();

			var result = sut.AddDoubles(1.1, 2.2);

			Assert.That(result, Is.EqualTo(30).Within(100));
		}

		// Also available:
		//    Is.Positive
		//    Is.Negative
		//    Is.NaN

	}
}
