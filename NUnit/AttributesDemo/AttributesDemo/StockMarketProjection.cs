using System.Threading;

namespace AttributesDemo {
    public class StockMarketProjection {
        public decimal CalculateShortTerm() {
            // simulated calculation

            return 200;
        }

        public decimal CalculateLongTerm() {
            Thread.Sleep(5000);

            return 50;
        }
    }
}
