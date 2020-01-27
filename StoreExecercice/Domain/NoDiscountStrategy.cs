using StoreExecercice.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace @StoreExecercice
{
    public class NoDiscountStrategy : IDiscountStrategy
    {
        public double ApplyDiscount( List<BasketCatalog> catalogs)
        {
            return catalogs.Sum(x => x.Price * x.Quantity);
        }
    }
}
