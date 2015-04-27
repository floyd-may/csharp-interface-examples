using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingExample
{
    class ConsoleLogger : ILogger
    {
        public void Debug(string message)
        {
            LogMessage(message, "DEBUG", ConsoleColor.Gray);
        }

        public void Info(string message)
        {
            LogMessage(message, "INFO", ConsoleColor.DarkCyan);
        }

        public void Warn(string message)
        {
            LogMessage(message, "WARN", ConsoleColor.Yellow);
        }

        public void Error(string message)
        {
            LogMessage(message, "ERROR", ConsoleColor.Red);
        }

        private void LogMessage(string message, string messageType, ConsoleColor color)
        {
            var oldColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(messageType);
            Console.ForegroundColor = oldColor;
            Console.WriteLine("({0:o}): {1}", DateTime.Now, message);
        }
    }
}
