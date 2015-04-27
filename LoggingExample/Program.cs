using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoggingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //var logger = new ConsoleLogger();
            var logger = new FileLogger("log.txt");

            var productionApp = new ProductionApp(logger);

            productionApp.Start();
        }
    }
}
