using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floydazon
{
    class PhysicalOrder : IOrder
    {
        public PhysicalOrder(string description, DateTime purchaseDate, bool delivered)
        {
        }

        public string Description
        {
            get;
            private set;
        }

        public DateTime PurchaseDate
        {
            get;
            private set;

        }

        public bool Delivered
        {
            get;
            private set;
        }

        public CancelResult Cancel()
        {
            if (this.Delivered)
            {
                return new CancelResult(false, "Item already delivered, cannot cancel order.");
            }

            return new CancelResult(true, "");
        }
    }
}
