using StoreExecercice.Interfaces;
using System.Collections.Generic;
using System.Linq;
namespace @StoreExecercice
{
    public class SameCategorySingleBookStrategy : IDiscountStrategy
    {
        public double ApplyDiscount(List<BasketCatalog> catalogs)
        {
            var price = catalogs.Sum(x => (x.Price * x.Discount) * x.Quantity);
            return price;
        }
    }
}
