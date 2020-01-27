using StoreExecercice.Models;
using StoreExecercice.Samples;
using System.Collections.Generic;
using System.Linq;
using StoreExecercice.Interfaces;
using StoreExecercice.Exceptions;

namespace @StoreExecercice
{
    public class Basket : IBasket
    {
        private BookStore _bookStore;
        private string[] _basketByNames;
        private static List<NameQuantity> _namesQuantities;

        public Basket(string[] basketByNames, BookStore bookStore)
        {
            _bookStore = bookStore;
            _basketByNames = basketByNames;
            _namesQuantities = new List<NameQuantity>();
        }

        public double GetTotalPrice()
        {
            var _listBasketCatalog = CatalogBasketBuillder(_basketByNames);
            CheckBasket();
            var catalogBasketCollections = BuilderCatalogCollections.Create(_listBasketCatalog);
            return ApplyDiscount(catalogBasketCollections);
        }

        private void CheckBasket()
        {
            if (_namesQuantities.Count > 0)
            {
                throw new NotEnoughInventoryException(_namesQuantities);
            }
        }

        private double ApplyDiscount(List<CatalogBasketCollections> catalogsUnion)
        {
            double totalPrice = default;
            foreach (var union in catalogsUnion)
            {
                switch (union.Discount)
                {
                    case DiscountType.NoDiscount:
                        var basket = new BasketApplyDiscount(new NoDiscountStrategy());
                        totalPrice += basket.GetPriceByDiscount(union.List);

                        break;
                    case DiscountType.SameCatalogSingleBook:
                        basket = new BasketApplyDiscount(new SameCategorySingleBookStrategy());
                        totalPrice += basket.GetPriceByDiscount(union.List);
                        break;
                    case DiscountType.ContainBookCopies:
                        basket = new BasketApplyDiscount(new CatalogUnionSameCatManyBooks());
                        totalPrice += basket.GetPriceByDiscount(union.List);
                        break;
                    default:
                        break;
                }
            }
            return totalPrice;
        }

        private List<BasketCatalog> CatalogBasketBuillder(params string[] basketByNames)
        {
            var _listBasketCatalog = new List<BasketCatalog>();
            var counter = 1;
            foreach (var name in basketByNames)
            {
                Category category = null;
                int quantity = 0;
                var catalog = _bookStore.Catalog
                    .FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
                if (catalog != null)
                {
                    category = _bookStore.Category
                       .FirstOrDefault(x => x.Name.ToLower() == catalog.Category.ToLower());
                    quantity = SetQuantity(basketByNames, catalog);
                    var basketCatalog = new BasketCatalog()
                    {
                        Id = counter,
                        Name = catalog.Name,
                        Category = category,
                        Price = catalog.Price,
                        Quantity = quantity,
                        Discount = (1 - category.Discount)
                    };

                    if (!_listBasketCatalog.Any(x => x.Name.ToLower() == basketCatalog.Name.ToLower()))
                    {
                        _listBasketCatalog.Add(basketCatalog);
                    }

                    counter++;
                }
            }
            return _listBasketCatalog;
        }

        private static int SetQuantity(string[] basketByNames, Catalog catalog)
        {

            var quantity=  basketByNames.Where(x => x.Equals(catalog.Name)).Count();
            if(quantity > catalog.Quantity)
            {
                if(! _namesQuantities.Any(x=>x.Name == catalog.Name))
                {
                    _namesQuantities.Add(
                        new NameQuantity
                        {
                            Name = catalog.Name,
                            Quantity = catalog.Quantity
                        });
                }
            }

            return quantity;
        }
    }
}
