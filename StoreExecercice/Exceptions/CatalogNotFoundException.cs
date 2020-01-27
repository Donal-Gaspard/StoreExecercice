using StoreExecercice.Interfaces;
using System;
using System.Collections.Generic;

namespace StoreExecercice.Exceptions
{
    public class CatalogNotFoundException : Exception
    {
        public IEnumerable<INameQuantity> Missing { get; }
    }
}
