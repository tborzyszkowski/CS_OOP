using System;

namespace LogLibrary.Code {
    public class Logging {
        private readonly IScrubSensitiveData _scrubSensitiveData;
        private readonly ICreateLogEntryHeaders _createLogEntryHeaders;
        private readonly ICreateLogEntryFooter _createLogEntryFooter;
        private readonly IConfigureSystem _systemConfiguration;

        public Logging(IScrubSensitiveData scrubSensitiveData,
                       ICreateLogEntryHeaders createLogEntryHeaders,
                       ICreateLogEntryFooter createLogEntryFooter,
                       IConfigureSystem systemConfiguration) {
            _scrubSensitiveData = scrubSensitiveData;
            _createLogEntryHeaders = createLogEntryHeaders;
            _createLogEntryFooter = createLogEntryFooter;
            _systemConfiguration = systemConfiguration;
        }

        public void CreateEntryFor(string message, LogLevel logLevel) {
            _createLogEntryHeaders.For(logLevel);

            if (_systemConfiguration.LogStackFor(logLevel))
            {
                Console.WriteLine(string.Format("Stack /n/n {0}",
                    Environment.StackTrace));
            }

            Console.WriteLine(string.Format("{0} - {1}",
                logLevel,
                _scrubSensitiveData.From(message)));

            _createLogEntryFooter.For(logLevel);
        }
    }
}