using StoreExecercice.Interfaces;
using System.Collections.Generic;

namespace @StoreExecercice
{
    public class CatalogBasketCollections : ICatalogBasketCollections
    {
        public List <BasketCatalog> List { get; set; }
        public DiscountType Discount { get; set; }
    }
}
