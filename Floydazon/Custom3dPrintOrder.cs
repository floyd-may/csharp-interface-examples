using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floydazon
{
    class Custom3dPrintOrder : IOrder
    {
        public Custom3dPrintStatus _status;

        public Custom3dPrintOrder(Custom3dPrintStatus status, DateTime purchaseDate, string description)
        {
            this.Description = "3D print order of " + description + " - currently " + status.ToString();
            this.PurchaseDate = purchaseDate;
            this._status = status;
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
            switch (_status)
            {
                case Custom3dPrintStatus.Waiting:
                case Custom3dPrintStatus.Validating:
                    return new CancelResult(true, "");
                case Custom3dPrintStatus.Printing:
                    return new CancelResult(false, "Cannot cancel, printing has already begun.");
                case Custom3dPrintStatus.Shipped:
                    return new CancelResult(false, "Cannot cancel, item has already shipped.");
                default:
                    throw new InvalidOperationException();
            }
        }

        
    }

    enum Custom3dPrintStatus
    {
        Waiting,
        Validating,
        Printing,
        Shipped
    }
}
