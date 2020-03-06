using System;
using NUnit.Framework;

namespace AssertDemo.Tests.Exceptions
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void ShouldErrorWhenDivideByZero()
        {
            var sut = new Calculator();

            Assert.That(() => sut.Divide(200, 0), Throws.Exception);            
        }


        [Test]
        public void ShouldErrorWhenDivideByZero_ExplicitExceptionType()
        {
            var sut = new Calculator();

            Assert.That(() => sut.Divide(99, 0), 
                Throws.TypeOf<DivideByZeroException>());
        }


        [Test]
        public void ShouldErrorWhenNumberTooBig()
        {
            var sut = new Calculator();

            Assert.That(() => sut.Divide(200, 2), 
                Throws.TypeOf<ArgumentOutOfRangeException>());
        }


        [Test]
        public void ShouldErrorWhenNumberTooBig_MoreExplicit()
        {
            var sut = new Calculator();

            Assert.That(() => sut.Divide(200, 2), 
                Throws.TypeOf<ArgumentOutOfRangeException>()
                .With.Matches<ArgumentOutOfRangeException>(x => x.ParamName == "value"));
        }
    }
}
