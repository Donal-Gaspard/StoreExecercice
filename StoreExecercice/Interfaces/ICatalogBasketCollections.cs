using System.Collections.Generic;

namespace @StoreExecercice.Interfaces
{
    public interface ICatalogBasketCollections
    {
        public List<BasketCatalog> List {get;set;}
        public DiscountType Discount { get; set; }
    }
}
