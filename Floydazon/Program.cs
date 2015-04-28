using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floydazon
{
    class Program
    {
        static void Main(string[] args)
        {
            var orders = GetOrders()
                .OrderBy(x => x.PurchaseDate)
                .ToList();

            Console.WriteLine("Orders:");
            foreach(var order in orders)
            {
                Console.WriteLine("\t{0} ({1:d})", order.Description, order.PurchaseDate);
            }

            Console.WriteLine();
            Console.WriteLine("Cancel results:");
            foreach(var order in orders)
            {
                var res = order.Cancel();

                if (res.Success)
                {
                    Console.WriteLine("Successfully cancelled order \"{0}\".", order.Description);
                }
                else
                {
                    Console.WriteLine("Failed to cancel \"{0}\": {1}", order.Description, res.Message);
                }
            }

            Console.ReadKey();
        }

        private static IEnumerable<IOrder> GetOrders()
        {
            // pretend that these are loaded out of a database
            yield return new PhysicalOrder("A toothbrush", new DateTime(2015, 2, 7), true);

            yield return new StreamingVideoOrder("Pastime of Big Chairs, Season One", new DateTime(2015, 2, 1), true);

            yield return new Custom3dPrintOrder(Custom3dPrintStatus.Printing, new DateTime(2015, 3, 28), "Brackets for a monitor stand");
            
            yield return new PhysicalOrder("Star Wars T-Shirt", new DateTime(2015, 4, 28), false);
            
            yield return new StreamingVideoOrder("Pastime of Big Chairs, Season Two", new DateTime(2015, 3, 1), true);

            yield return new StreamingVideoOrder("Pastime of Big Chairs, Season Eleventeen", new DateTime(2015, 4, 1), false);

            yield return new Custom3dPrintOrder(Custom3dPrintStatus.Waiting, new DateTime(2015, 4, 26), "Guitar pedal enclosure");
            
        }
    }
}
