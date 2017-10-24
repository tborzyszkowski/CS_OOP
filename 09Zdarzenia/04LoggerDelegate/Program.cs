using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04LoggerDelegate {
    class Program {
        public static void LogToConsole(string message) {
            Console.Error.WriteLine(message);
        }

        static void Main(string[] args) {
            var file = new FileLogger("log.txt");

            Logger.LogMessage(Severity.Information, "Test1", "Msg1");
            Logger.LogMessage(Severity.Error, "Test2", "Msg2");

            Logger.WriteMessage += LogToConsole;
            Logger.LogMessage(Severity.Error, "Test3", "Msg3");

            Logger.WriteMessage -= LogToConsole;
            Logger.LogMessage(Severity.Error, "Test4", "Msg4");

            file.DetachLog();
            Logger.LogMessage(Severity.Error, "Test5", "Msg5");

        }
    }
}
