using StoreExecercice.Interfaces;
using System.Collections.Generic;

namespace @StoreExecercice
{
    public class CatalogUnionSameCatManyBooks : IDiscountStrategy
    {
        public double ApplyDiscount(List<BasketCatalog> catalogs)
        {
            double price = 0.0;
            foreach(var catalog in catalogs)
            {
                price += (catalog.Price * catalog.Discount) + catalog.Price * (catalog.Quantity - 1);
            }

            return price; 
        }
    }
}
