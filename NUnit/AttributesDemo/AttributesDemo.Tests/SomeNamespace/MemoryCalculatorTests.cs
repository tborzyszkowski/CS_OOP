using System;
using NUnit.Framework;

namespace AttributesDemo.Tests.SomeNamespace {
	[TestFixture]
	public class MemoryCalculatorTests {
		MemoryCalculator sut = new MemoryCalculator();

		[Test]
		public void ShouldAdd() {
			sut.Add(10);
			sut.Add(5);

			Assert.That(sut.CurrentValue, Is.EqualTo(15));
		}


		[Test]
		public void ShouldSubtract() {
			sut.Subtract(5);

			Assert.That(sut.CurrentValue, Is.EqualTo(-5));
		}

		[SetUp]
		public void BeforeEachTest() {
			Console.WriteLine($"Before {TestContext.CurrentContext.Test.Name}");
			//sut = new MemoryCalculator();
			sut.Reset();
		}

		[TearDown]
		public void AfterEachTest() {
			Console.WriteLine($"After {TestContext.CurrentContext.Test.Name}");

			//sut = null;
		}

	}
}
