using NUnit.Framework;

namespace AssertDemo.Tests.Equality
{
    [TestFixture]
    public class NameJoinerTests
    {
        [Test]
        public void ShouldJoinNames()
        {
            var sut = new NameJoiner();

            var fullName = sut.Join("Sarah", "Smith");

            Assert.That(fullName, Is.EqualTo("Sarah Smith"));
        }


        [Test]
        public void ShouldJoinNames_CaseInsensitiveAssertDemo()
        {
            var sut = new NameJoiner();

            var fullName = sut.Join("sarah", "smith");

            Assert.That(fullName, Is.EqualTo("SARAH SMITH").IgnoreCase);
        }


        [Test]
        public void ShouldJoinNames_NotEqualDemo()
        {
            var sut = new NameJoiner();

            var fullName = sut.Join("Sarah", "Smith");

            Assert.That(fullName, Is.Not.EqualTo("Gentry Smith"));
        }        
    }
}
