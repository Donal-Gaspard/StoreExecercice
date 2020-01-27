using NUnit.Framework;
using StoreExecercice;
using StoreExecercice.Exceptions;
using System;
using System.IO;
using System.Linq;

namespace StoreExcerciceUnitTests
{
    public class BookStoreUnitTests
    {
        private Store _store;
        private string _jsonStorePath;
        [SetUp]
        public void Setup()
        {
            _store = new Store();
             _jsonStorePath = "JSONBook.json";
        }

        [Test]
        public void ShouldBeFileNotFoundException()
        {
            var fileName = "defrdeszderfr";
            Assert.Throws<FileNotFoundException>(() => _store.Import(fileName));
        }

        [Test]
        public void ShoudBeLoadJSONFile()
        {
            
            Console.WriteLine($"TestContext {TestContext.CurrentContext.TestDirectory}");
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, _jsonStorePath);
            TestContext.Out.WriteLine(path);
             _store.Import(path);
            Assert.IsNotNull(_store.BooksShop);
        }

        [Test]
        public void Should_Be_Equal_10()
        {
            var name = "J.K Rowling - Goblet Of fire";
            _store.Import(_jsonStorePath);
            Assert.AreEqual(_store.Quantity(name),2);
        }
  

        [Test]
        public void Should_Be_equal_to_0_When_Catalog_Not_Exist()
        {
            var name = "deifrjgojojifdede";
            _store.Import(_jsonStorePath);
            Assert.AreEqual(_store.Quantity(name),0);
        }

        [Test]
        public void Should_Be_Not_Null_when_BuilderCatalogCollections()
        {
            var catalogsBasket = BookStoreUnitTestsUtility.CatalogBasketCollectionsNoDiscount();
            var catalogCollection = BuilderCatalogCollections.Create(catalogsBasket);
            Assert.IsNotNull(catalogCollection);
        }

        [Test]
        public void Should_Be_Classify_Catalog_Type_NoDsicount()
        {
            var catalogsBasket = BookStoreUnitTestsUtility.CatalogBasketCollectionsNoDiscount();
            var catalogCollection = BuilderCatalogCollections.Create(catalogsBasket);
            Assert.AreEqual(catalogCollection.Count,1);
            Assert.AreEqual(catalogCollection.First().Discount, DiscountType.NoDiscount);
        }

        [Test]
        public void Should_Be_Classify_Catalog_Equal_2()
        {
            var catalogsBasket = BookStoreUnitTestsUtility.CatalogBasketCollectionsNoDiscountAndSameCategory();
            var catalogCollection = BuilderCatalogCollections.Create(catalogsBasket);
            Assert.AreEqual(catalogCollection.Count, 2);
            Assert.AreEqual(catalogCollection[0].Discount, DiscountType.NoDiscount);
            Assert.AreEqual(catalogCollection[1].Discount, DiscountType.SameCatalogSingleBook);
        }
        [Test]
        public void Should_Be_StoreNotLoadExceException_when_Store_Not_Load()
        {
            var name = "deifrjgojojifdede";
            Assert.Throws<StoreNotLoadExceException>(() => _store.Quantity(name));
        }

        [Test]
        public void Should_Be_Type_SameCatalogManyBooks_When_Quantity_More_Tan_1()
        {
            var catalogsBasket = BookStoreUnitTestsUtility.CatalogManyBooksCopies();
            var catalogCollection = BuilderCatalogCollections.Create(catalogsBasket);
            Assert.AreEqual(catalogCollection.Count, 1);
            Assert.AreEqual(catalogCollection[0].Discount, DiscountType.ContainBookCopies);
        }


        [Test]
        public void Should_Be_Type_NoDiscount_SingleBook_ManyCopies()
        {
            var catalogsBasket = BookStoreUnitTestsUtility.CatalogNoDiscountSameCategoryAndManyBooks();
            var catalogCollection = BuilderCatalogCollections.Create(catalogsBasket);
            Assert.AreEqual(catalogCollection.Count, 3);
            Assert.AreEqual(catalogCollection[0].Discount, DiscountType.NoDiscount);
            Assert.AreEqual(catalogCollection[1].Discount, DiscountType.SameCatalogSingleBook);
            Assert.AreEqual(catalogCollection[2].Discount, DiscountType.ContainBookCopies);

        }

        [Test]
        public void Should_Be_Have_All_Book_In_Basket()
        {
            var catalogsBasket = BookStoreUnitTestsUtility.CatalogNoDiscountSameCategoryAndManyBooks();
            var catalogCollection = BuilderCatalogCollections.Create(catalogsBasket);
            Assert.AreEqual(catalogCollection.Sum(x=>x.List.Count), catalogsBasket.Count);
        }


        [Test]
        public void Should_Be_Equal_To_12_When_Buy_1_Book_No_Discount()
        {
            _store.Import(_jsonStorePath);
            var price = _store.Buy("Ayn Rand - FountainHead");
            Assert.AreEqual(price, 12);
        }

        [Test]
        public void Should_Be_Equal_To_28_When_Buy_2_Book_No_Discount()
        {
            _store.Import(_jsonStorePath);
            var price = _store.Buy("Ayn Rand - FountainHead", "Isaac Asimov - Foundation");
            Assert.AreEqual(price, 28);
        }


        [Test]
        public void Should_Be_Equal_To_18_When_Buy_2_Book_DiscountSameCat()
        {
            _store.Import(_jsonStorePath);
            var price = _store.Buy("J.K Rowling - Goblet Of fire", "Robin Hobb - Assassin Apprentice");
            Assert.AreEqual(price, 18);
        }


        [Test]
        public void Should_Be_Equal_To_15_When_Buy_2_CopyBooks()
        {
            _store.Import(_jsonStorePath);
            var price = _store.Buy("J.K Rowling - Goblet Of fire", "J.K Rowling - Goblet Of fire");
            Assert.AreEqual(price, 15.2);
        }

        [Test]
        public void Should_Be_Equal_To_15_When_Buy_2_Copies_Books()
        {
            _store.Import(_jsonStorePath);
            var catalogs = new string[] { "J.K Rowling - Goblet Of fire", 
                "J.K Rowling - Goblet Of fire" , "Ayn Rand - FountainHead", "Ayn Rand - FountainHead" };
            var price = _store.Buy(catalogs);
            Assert.AreEqual(price, 37.4);
        }

        [Test]
        public void Should_Be_Equal_To_30_When_Example1()
        {
            _store.Import(_jsonStorePath);
            var catalogs = new string[]
            {
                "J.K Rowling - Goblet Of fire",
                "Robin Hobb - Assassin Apprentice",
                "Robin Hobb - Assassin Apprentice",
            };
            var price = _store.Buy(catalogs);
            Assert.AreEqual(price, 30);
        }

        [Test]
        public void Should_Be_Equal_To_69_When_Example2()
        {
            _store.Import(_jsonStorePath);
            var catalogs = new string[]
            {
                "Ayn Rand - FountainHead",
                "Isaac Asimov - Robot series",
                "Isaac Asimov - Foundation",
                "J.K Rowling - Goblet Of fire",
                "J.K Rowling - Goblet Of fire",
                "Robin Hobb - Assassin Apprentice",
                "Robin Hobb - Assassin Apprentice"
            };
            var price = _store.Buy(catalogs);
            Assert.AreEqual(price, 69.95);
        }

        [Test]
        public void Should_Be_Equal_To_0_When_No_Catalog_Found()
        {
            _store.Import(_jsonStorePath);
            var catalogs = new string[]
            {
                "defrfdefr",
            };
            var price = _store.Buy(catalogs);
            Assert.AreEqual(price, 0);
        }

        [Test]
        public void Should_Be_Equal_To_0_When_enough_Quantity()
        {
            _store.Import(_jsonStorePath);
            var catalogs = new string[]
            {
                "J.K Rowling - Goblet Of fire",
                "J.K Rowling - Goblet Of fire",
                "J.K Rowling - Goblet Of fire",
            };

            var excep =Assert.Throws<NotEnoughInventoryException>(
                () => _store.Buy(catalogs));
            Assert.AreEqual(excep.Missing.Count, 1);
            Assert.AreEqual(excep.Missing[0].Name, "J.K Rowling - Goblet Of fire");
        }
    }
}