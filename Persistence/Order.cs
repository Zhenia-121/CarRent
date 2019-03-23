using System;
using System.Collections.Generic;

namespace CarRent
{
    public partial class Order
    {
        public int Id { get; set; }
        public DateTime RentStart { get; set; }
        public DateTime RentEnd { get; set; }
        public string Comment { get; set; }
        public int? UserId { get; set; }
        public int? CarId { get; set; }

        public virtual Car Car { get; set; }
        public virtual User User { get; set; }
    }
}
