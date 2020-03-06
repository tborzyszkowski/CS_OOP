using System;
using NUnit.Framework;

namespace AssertDemo.Tests.Equality
{
    [TestFixture]
    public class InequalityDemo
    {
        [Test]
        public void NotModifier()
        {
            var sut = new Calculator();

            var result = sut.AddInts(1, 2);

            Assert.That(result, Is.Not.EqualTo(4));
        }

        [Test]
        public void NotModifierWithStrings()
        {
            Assert.That("a", Is.Not.EqualTo("A"));
        }
    }
}
