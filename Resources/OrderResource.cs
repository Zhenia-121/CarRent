using System;

namespace CarRent.Resources
{
    public class OrderResource
    {
        public int Id { get; set; }
        public DateTime RentStart { get; set; }
        public DateTime RentEnd { get; set; }
        public string Comment { get; set; }

        public virtual CarResource Car { get; set; }
        public virtual UserResource User { get; set; }
    }
}