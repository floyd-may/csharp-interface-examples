using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingExample
{
    class FileLogger : ILogger
    {
        private string _path;

        public FileLogger(string path)
        {
            _path = path;
        }

        public void Debug(string message)
        {
            LogMessage(message, "DEBUG");
        }

        public void Info(string message)
        {
            LogMessage(message, "INFO");
        }

        public void Warn(string message)
        {
            LogMessage(message, "WARN");
        }

        public void Error(string message)
        {
            LogMessage(message, "ERROR");
        }

        private void LogMessage(string message, string messageType)
        {
            var text = string.Format("{0} ({1:o}): {2}{3}", messageType, DateTime.Now, message, Environment.NewLine);

            File.AppendAllText(_path, text, Encoding.ASCII);
        }
    }
}
