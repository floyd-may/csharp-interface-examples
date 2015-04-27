using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoggingExample
{
    sealed class ProductionApp
    {
        private ILogger _logger;

        public ProductionApp(ILogger logger)
        {
            _logger = logger;
        }

        public void Start()
        {
            var stop = false;

            Console.CancelKeyPress += (o, e) => stop = true;

            var rand = new Random();
            while (!stop)
            {
                var choice = rand.Next(0, 4);
                switch (choice)
                {
                    case 0:
                        _logger.Debug("some debug info");
                        break;
                    case 1:
                        _logger.Info("an info message");
                        break;
                    case 2:
                        _logger.Warn("something mildly bad");
                        break;
                    case 3:
                        _logger.Error("something catastrophic");
                        break;
                }
                Thread.Sleep(TimeSpan.FromSeconds(rand.Next(1, 4) / 2.0));
            }
        }
    }
}
