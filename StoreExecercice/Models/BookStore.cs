using StoreExecercice.Interfaces;
using System.Collections.Generic;

namespace StoreExecercice.Models
{
    public class BookStore : IBookStore
    {
        public List<Category> Category { get; set; }
        public List<Catalog> Catalog { get; set; }
    }
}
