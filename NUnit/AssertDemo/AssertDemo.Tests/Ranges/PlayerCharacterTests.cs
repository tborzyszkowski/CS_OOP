using NUnit.Framework;

namespace AssertDemo.Tests.Ranges
{
    [TestFixture]
    public class PlayerCharacterTests
    {
        [Test]
        public void ShouldIncreaseHealthAfterSleeping()
        {
            var sut = new PlayerCharacter {Health = 100};

            sut.Sleep();

            Assert.That(sut.Health, Is.GreaterThan(100));
        }

        [Test]
        public void ShouldIncreaseHealthInExpectedRangeAfterSleeping()
        {
            var sut = new PlayerCharacter { Health = 100 };

            sut.Sleep();

            Assert.That(sut.Health, Is.InRange(101, 200));            
        }

        // Also available:
        //    Is.GreaterThanOrEqualTo()
        //    Is.LessThan()
        //    Is.LessThanOrEqualTo()
    }
}
