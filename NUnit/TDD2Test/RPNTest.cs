using NUnit.Framework;
using System;
using TDD2;

namespace TDD2Test
{
	[TestFixture]
	public class RPNTest
	{
		private RPN _sut;
		[SetUp]
		public void Setup()
		{
			_sut = new RPN();

		}
		[Test]
		public void CheckIfTestWorks()
		{
			Assert.Pass();
		}
		
		[Test]
		public void CheckIfCanCreateSut()
		{
			Assert.That(_sut, Is.Not.Null);
		}

		[Test]
		public void SingleDigitOneInputOneReturn()
		{
			var result = _sut.EvalRPN("1");

			Assert.That(result, Is.EqualTo(1));

		}
		[Test]
		public void SingleDigitOtherThenOneInputNumberReturn()
		{
			var result = _sut.EvalRPN("2");

			Assert.That(result, Is.EqualTo(2));

		}
		[Test]
		public void TwoDigitsNumberInputNumberReturn()
		{
			var result = _sut.EvalRPN("12");

			Assert.That(result, Is.EqualTo(12));

		}
		[Test]
		public void TwoNumbersGivenWithoutOperator_ThrowsExcepton()
		{
			Assert.Throws<InvalidOperationException>(() => _sut.EvalRPN("1 2"));

		}
		[Test]
		public void OperatorPlus_AddingTwoNumbers_ReturnCorrectResult()
		{
			var result = _sut.EvalRPN("1 2 +");

			Assert.That(result, Is.EqualTo(3));
		}
		[Test]
		public void OperatorTimes_AddingTwoNumbers_ReturnCorrectResult()
		{
			var result = _sut.EvalRPN("2 2 *");

			Assert.That(result, Is.EqualTo(4));
		}
		[Test]
		public void OperatorMinus_SubstractingTwoNumbers_ReturnCorrectResult()
		{
			var result = _sut.EvalRPN("1 2 -");

			Assert.That(result, Is.EqualTo(1));
		}
		[Test]
		public void ComplexExpression()
		{
			var result = _sut.EvalRPN("15 7 1 1 + - / 3 * 2 1 1 + + -");

			Assert.That(result, Is.EqualTo(4));
		}
	}
}
