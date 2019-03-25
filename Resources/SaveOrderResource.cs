using System;
using System.ComponentModel.DataAnnotations;

namespace CarRent.Resources
{
    public class SaveOrderResource
    {
        [Required]
        public DateTime RentStart { get; set; }
        [Required]
        public DateTime RentEnd { get; set; }
        [Required]
        public string Comment { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int CarId { get; set; }
    }
}