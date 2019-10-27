using NUnit.Framework;
using System;
using TDD2;

namespace TDD2Test
{
	[TestFixture]
	class StackTest
	{
		private Stack<int> _sut;
		[SetUp]
		public void Setup()
		{
			_sut = new Stack<int>();
		}

		[Test]
		public void CheckIfCanCreateSut()
		{
			Assert.That(_sut, Is.Not.Null);
		}

		[Test]
		public void Push_SingleNumberAddedToStack_WhenPeekNumberIstheSame()
		{
			// Arrange
			_sut.Push(5);
			// Act
			var result = _sut.Peek();
			// Assert
			Assert.That(result, Is.EqualTo(5));
		}
		[Test]
		public void Push_TwoNumbersAddedToStack_LastOnePeekd()
		{
			_sut.Push(5);
			_sut.Push(7);
			var result = _sut.Peek();

			Assert.That(result, Is.EqualTo(7));
		}
		[Test]
		public void Pop_TwoNumbersPushedToStack_CorrectNumberReturnedByTheSndPop()
		{
			_sut.Push(5);
			_sut.Push(7);
			_sut.Pop();
			var result = _sut.Pop();

			Assert.That(result, Is.EqualTo(5));
		}

		[Test]
		public void Push_ThousendElementsPushedAndAllPoped_FirstPushedReturned()
		{
			for(int i = 0; i<1000; i++)
			{
				_sut.Push(i);
			}
			var result = -1;
			for (int i = 0; i < 1000; i++)
			{
				result = _sut.Pop();
			}
			Assert.That(result, Is.EqualTo(0));
		}

		[Test]
		public void Pop_TooManyPopsCalled_InvalidOperationException()
		{
			_sut.Push(1);

			_sut.Pop();

			Assert.Throws<InvalidOperationException>(()=>_sut.Pop());
		}
		[Test]
		public void Peek_StackIsEmpty_InvalidOperationException()
		{
			Assert.Throws<InvalidOperationException>(() => _sut.Peek());
		}

		[Test]
		public void IsEmpty_StackIsEmpty_ReturnedTrue()
		{
			Assert.That(_sut.IsEmpty, Is.EqualTo(true));
		}
		[Test]
		public void IsEmpty_StackHasElements_ReturnedFalse()
		{
			_sut.Push(1);

			Assert.That(_sut.IsEmpty, Is.EqualTo(false));
		}
	}
}
