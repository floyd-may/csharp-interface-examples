using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floydazon
{
    class PhysicalOrder : IOrder
    {
        private bool _shipped;

        public PhysicalOrder(string description, DateTime purchaseDate, bool shipped)
        {
            Description = description;
            PurchaseDate = purchaseDate;
            _shipped = shipped;
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

        public CancelResult Cancel()
        {
            if (this._shipped)
            {
                return new CancelResult(false, "Item already shipped, cannot cancel order.");
            }

            return new CancelResult(true, "");
        }
    }
}
