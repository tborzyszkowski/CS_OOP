using NUnit.Framework;

namespace AttributesDemo.Tests.DataDrivenTests
{  
    [TestFixture]
    [Category("money")]
    public class StockMarketProjectionTests
    {        
        [Test]
        [Ignore("powody")]
        public void ShouldProjectShortTerm()
        {
            var sut = new StockMarketProjection();

            var marketValue = sut.CalculateShortTerm();

            Assert.That(marketValue, Is.EqualTo(200));
        }


        [Test]
        [Category("long")]
        [MaxTime(5500)]
        public void ShouldProjectLongTerm()
        {
            var sut = new StockMarketProjection();

            var marketValue = sut.CalculateLongTerm();

            Assert.That(marketValue, Is.EqualTo(50));
        }
    }
}
