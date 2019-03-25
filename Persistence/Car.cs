using System;
using System.Collections.Generic;

namespace CarRent
{
    public partial class Car
    {
        public Car()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Class { get; set; }
        public short ModelYear { get; set; }
        public string RegistrationNumber { get; set; }

        public virtual ICollection<Order> Orders { get; private set; }
    }
}
