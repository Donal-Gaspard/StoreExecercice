using StoreExecercice;
using StoreExecercice.Models;
using System.Collections.Generic;

namespace StoreExcerciceUnitTests
{
    static class BookStoreUnitTestsUtility
    {

        public static List<BasketCatalog> CatalogNoDiscountSameCategoryAndManyBooks()
        {
            var list = new List<BasketCatalog>()
            {

                new BasketCatalog()
                {
                    Id=1,
                    Price=8,
                    Name= "Isaac Asimov - Robot series",
                    Quantity =1,
                    Category= new Category()
                    {
                        Name= "Science Fiction", Discount = 0.05
                    }
                },
                new BasketCatalog()
                {
                    Id=1,
                    Price=8,
                    Name= "J.K Rowling - Goblet Of fire",
                    Quantity =1,
                    Category= new Category()
                    {
                        Name= "Fantastique", Discount = 0.1
                    }
                },
                new BasketCatalog()
                {
                    Id=2,
                    Price=8, Name= "Ayn Rand - FountainHead",Quantity =2,
                    Category= new Category()
                    {
                        Name= "Philosophy", Discount = 0.15
                    }
                },
                new BasketCatalog()
                {
                    Id=3, Price=8, Name= "Robin Hobb - Assassin Apprentice", Quantity =1,
                    Category= new Category()
                    {
                        Name= "Fantastique", Discount = 0.1
                    }
                },
            };

            return list;
        }
       public static List<BasketCatalog> CatalogManyBooksCopies()
        {
            var list = new List<BasketCatalog>()
            {
                new BasketCatalog()
                {
                    Id=1, Price=8,Name= "J.K Rowling - Goblet Of fire",Quantity= 2,
                    Category= new Category()
                    {
                        Name= "Fantastique", Discount = 0.1
                    }
                }
            };

            return list;
        }



        public static List<BasketCatalog> CatalogBasketCollectionsNoDiscountAndSameCategory()
        {
            var list = new List<BasketCatalog>()
            {
                new BasketCatalog()
                {
                    Id=1, Price=8,Name= "J.K Rowling - Goblet Of fire",Quantity =1,
                    Category= new Category()
                    {
                        Name= "Fantastique", Discount = 0.1
                    }
                },
                new BasketCatalog()
                {
                    Id=2, Price=8, Name= "Ayn Rand - FountainHead",Quantity =1,
                    Category= new Category()
                    {
                        Name= "Philosophy", Discount = 0.15
                    }
                },
                new BasketCatalog()
                {
                    Id=3, Price=8, Name= "Robin Hobb - Assassin Apprentice", Quantity =1,
                    Category= new Category()
                    {
                        Name= "Fantastique", Discount = 0.1
                    }
                },
            };

            return list;
        }

        public static List<BasketCatalog> CatalogBasketCollectionsNoDiscount()
        {
            var list = new List<BasketCatalog>()
            {
                new BasketCatalog()
                {
                    Id=1, Price=8,Name= "J.K Rowling - Goblet Of fire",Quantity =1,
                    Category= new Category()
                    {
                        Name= "Fantastique", Discount = 0.1
                    }
                },
                new BasketCatalog()
                {
                    Id=2, Price=8, Name= "Ayn Rand - FountainHead",Quantity =1,
                    Category= new Category()
                    {
                        Name= "Philosophy", Discount = 0.15
                    }
                }
            };

            return list;
        }
    }
}
