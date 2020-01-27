using StoreExecercice.Interfaces;
using System.Collections.Generic;

namespace @StoreExecercice
{
    public class CatalogSingleCatUniqueBook : ICatalogBasketCollections
    {
        public List<BasketCatalog> List { get; set; }
        public DiscountType Discount { get; set; }
    }
}
