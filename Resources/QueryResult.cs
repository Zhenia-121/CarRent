using System.Collections.Generic;

namespace CarRent.Resources
{
    public class QueryResult<T>
    {
        public IEnumerable<T> Items;
        public int TotalItems { get; set; }
    }
}