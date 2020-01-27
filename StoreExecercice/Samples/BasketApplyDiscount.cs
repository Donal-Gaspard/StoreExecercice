using StoreExecercice.Interfaces;
using System.Collections.Generic;

namespace @StoreExecercice.Samples
{
    public class BasketApplyDiscount
    {
        private IDiscountStrategy _discountStrategy;
        private double TotalPrice { get; set; }
        public double GetTotalPrice { get; set; }

        public BasketApplyDiscount(IDiscountStrategy discountStrategy )
        {
            _discountStrategy = discountStrategy;
        }
        public double  GetPriceByDiscount(List<BasketCatalog> catologs)
        {
            return _discountStrategy.ApplyDiscount(catologs);
        }

    }
}
