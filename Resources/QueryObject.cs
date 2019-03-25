

using System;

namespace CarRent.Resources
{
    public class QueryObject: IQueryObject
    {
        public DateTime? RentStart { get; set; }

        public DateTime? RentEnd { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string UserName { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}