using NUnit.Framework;

namespace AssertDemo.Tests.NullsAndBooleans
{
    [TestFixture]
    public class PlayerCharacterTests
    {
        [Test]
        public void ShouldHaveDefaultRandomGeneratedName()
        {
            var sut = new PlayerCharacter();           

            Assert.That(sut.Name, Is.Not.Empty);
        }


        [Test]
        public void ShouldNotHaveANickName()
        {
            var sut = new PlayerCharacter();

            Assert.That(sut.NickName, Is.Null);
        }


        [Test]
        public void ShouldBeNewbie()
        {
            var sut = new PlayerCharacter();

            Assert.That(sut.IsNoob, Is.True);
        }
    }
}
