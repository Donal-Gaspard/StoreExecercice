using System.Collections.Generic;

namespace @StoreExecercice.Interfaces
{
    public interface  IDiscountStrategy
    {
        double ApplyDiscount(List<BasketCatalog> catologs);
    }
}
