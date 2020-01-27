using System;
using System.Collections.Generic;

namespace @StoreExecercice.Exceptions
{
    public class NotEnoughInventoryException : Exception
    {
        public NotEnoughInventoryException(List<NameQuantity> missing)
        {
            Missing = missing;
        }
        public List<NameQuantity> Missing { get; }
    }
    
    
}
