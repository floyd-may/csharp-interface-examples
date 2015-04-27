using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floydazon
{
    interface IOrder
    {
        string Description { get; }

        DateTime PurchaseDate { get; }

        bool Delivered { get; }

        CancelResult Cancel();
    }

    sealed class CancelResult
    {
        public string Message { get; private set; }

        public bool Success { get; private set; }

        public CancelResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
