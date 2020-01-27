using System;

namespace StoreExecercice
{
    class Program
    {
        static void Main(string[] args)
        {
            var JsonStorePath = "Samples/JSONBook.json";
            var Store = new Store();
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
            Console.WriteLine("Loading store ...");
            Store.Import(JsonStorePath);
            int quantity = Store.Quantity("J.K Rowling - Goblet Of fire");
            Console.WriteLine($"Nb quantity of J.K Rowling - Goblet Of fire : {quantity}\n");
            double totalPrice = Store.Buy(catalogs);
            Console.WriteLine($"total price for catalogs : {totalPrice}");
            Console.ReadKey();
        }
    }
}
