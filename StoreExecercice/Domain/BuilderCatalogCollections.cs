using System.Collections.Generic;
using System.Linq;

namespace @StoreExecercice
{
    public static class BuilderCatalogCollections
    {
        private static List<CatalogBasketCollections> _catalogCollections;
        public static List<CatalogBasketCollections> Create(List<BasketCatalog> catalogBaskets)
        {
            _catalogCollections = new List<CatalogBasketCollections>();
            AddCollection( RulesisNoDiscount(catalogBaskets));
            AddCollection(RulesSameCatalogSingleBook(catalogBaskets));
            AddCollection( RulesSameCatalogManyBooks(catalogBaskets));
            return _catalogCollections;
        }

        private static void  AddCollection(CatalogBasketCollections collection)
        {
            if(collection.List.Count > 0)
            {
                _catalogCollections.Add(collection);
            }
        }
        private static CatalogBasketCollections RulesisNoDiscount(List<BasketCatalog> catalogBaskets) 
        {
            var singleCategories = catalogBaskets.GroupBy(x => x.Category.Name)
                .Where(grp => grp.Count() == 1)
                .Select(grp => grp.Key).ToList();

            // get single book 
            return new CatalogBasketCollections()
            {
                List = catalogBaskets
                .Where(x => singleCategories.Contains(x.Category.Name) && x.Quantity==1).ToList(),
                Discount = DiscountType.NoDiscount
            };
        }

        private static CatalogBasketCollections RulesSameCatalogSingleBook(List<BasketCatalog> catalogBaskets)
        {
            // get catalog name same catalog
            var namesCategories = catalogBaskets
                .GroupBy(x => new { categoryName = x.Category.Name })
                .Where(grp => grp.Count() > 1).Select(grp => grp.Key)
                .ToList();

            var catalogs = catalogBaskets.Join(namesCategories,
                cat => cat.Category.Name,
                catName => catName.categoryName,
                (cat, catName) => new { cat, catName })
                .Where(x => x.cat.Category.Name == x.catName.categoryName && x.cat.Quantity == 1)
                .Select(x => x.cat).ToList();

            return new CatalogBasketCollections()
            {
                List = catalogs,
                Discount = DiscountType.SameCatalogSingleBook
            };
        }

        private static CatalogBasketCollections RulesSameCatalogManyBooks(List<BasketCatalog> catalogBaskets)
        {
            // get catalog copy same catalog
            return new CatalogBasketCollections()
            {
                List = catalogBaskets.Where(x=>x.Quantity >1).ToList(),
                Discount = DiscountType.ContainBookCopies
            };
        }

    }
}
