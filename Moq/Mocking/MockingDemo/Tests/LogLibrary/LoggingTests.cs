using NUnit.Framework;
using LogLibrary.Code;

namespace LogLibrary.Tests {
    public class MockScrubber : IScrubSensitiveData {
        public string From(string messageToScrub) {
            FromWasCalled = true;
            return string.Empty;
        }

        public bool FromWasCalled { get; private set; }
    }

    [TestFixture]
    public class When_logging {
        private MockScrubber _mockScrubber;
        private MockHeader _mockHeader;
        private MockFooter _mockFooter;
        private MockSystemConfig _mockSystemConfig;

        [SetUp]
        public void Setup() {
            _mockScrubber = new MockScrubber();
            _mockHeader = new MockHeader();
            _mockFooter = new MockFooter();
            _mockSystemConfig = new MockSystemConfig();

            var logger = new Logging(_mockScrubber, _mockHeader,
                _mockFooter, _mockSystemConfig);
            logger.CreateEntryFor("my message", LogLevel.Info);
        }

        [Test]
        public void sensitive_data_should_be_scrubbed_from_the_log_message() {
            Assert.That(_mockScrubber.FromWasCalled);
        }

        [Test]
        public void entry_headers_should_be_created() {

        }

        [Test]
        public void the_system_configuration_should_be_checked_for_stack_logging() {

        }


        [Test]
        public void entry_footers_should_be_created() {

        }
    }

    internal class MockSystemConfig : IConfigureSystem {
        public bool LogStackFor(LogLevel logLevel) {
            return false;
        }
    }

    public class MockFooter : ICreateLogEntryFooter {
        public void For(LogLevel logLevel) {

        }
    }

    public class MockHeader : ICreateLogEntryHeaders {
        public void For(LogLevel logLevel) {

        }
    }
}
