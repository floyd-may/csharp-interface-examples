using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floydazon
{
    class StreamingVideoOrder : IOrder
    {
        private bool _watched;

        public StreamingVideoOrder(string title, DateTime purchaseDate, bool watched)
        {
            this._watched = watched;
            this.PurchaseDate = purchaseDate;
            this.Description = title + " - via Floydazon Streaming Video";
        }
        public string Description
        {
            get; private set;
        }

        public DateTime PurchaseDate
        {
            get; private set;
        }

        public CancelResult Cancel()
        {
            if (this._watched)
            {
                return new CancelResult(false, "Video has been watched already, no cancel for you!");
            }

            return new CancelResult(true, "");
        }
    }
}
