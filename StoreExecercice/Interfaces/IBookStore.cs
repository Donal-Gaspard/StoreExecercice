using StoreExecercice.Models;
using System.Collections.Generic;

namespace @StoreExecercice.Interfaces
{
    public class IBookStore
    {
        List<Category> Category { get; set; }
        List<Catalog> Catalog { get; set; }
    }
}
