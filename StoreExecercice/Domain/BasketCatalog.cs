using StoreExecercice.Models;

namespace @StoreExecercice
{
    public class BasketCatalog
    {
        public int Id  {get;set;}
        public string Name { get; set; }
        public Category Category { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public double Discount { get; set; }
    }
}
