using Newtonsoft.Json;
using StoreExecercice.Exceptions;
using StoreExecercice.Models;
using System.IO;
using System.Linq;

namespace StoreExecercice
{
    public class Store : IStore
    {

        public BookStore BooksShop => _booksShop;
        private BookStore _booksShop;
        private Basket _basket ;
        public Store()
        {
        }

        public void Import(string catalogAsJson)
        {
            if (!File.Exists(catalogAsJson))
            {
                throw new FileNotFoundException();
            }
            try
            {
                using StreamReader reader = new StreamReader(catalogAsJson);
                string json = reader.ReadToEnd();
                _booksShop = JsonConvert.DeserializeObject<BookStore>(json);
            }
            catch
            {
                throw;
            }
        }

        public int Quantity(string name)
        {
            if (_booksShop == null)
            {
                throw new StoreNotLoadExceException("The store hasn't been loaded");
            }

            return (_booksShop.Catalog.FirstOrDefault(x => x.Name.ToLower() == name.ToLower()) != null) ?
                _booksShop.Catalog.FirstOrDefault(x => x.Name.ToLower() == name.ToLower()).Quantity 
                : 0;
        }

        public double Buy(params string[] basketByNames)
        {
            if (_booksShop == null)
            {
                throw new StoreNotLoadExceException("The store hasn't been loaded");
            }
            _basket = new Basket(basketByNames, _booksShop);
            return _basket.GetTotalPrice();
        }
    }
}
