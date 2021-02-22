using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DALnew.Entities
{
    public class Tour
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string DeparturePlace { get; set; }
        [Required]
        public DateTime DepartureDate { get; set; }
        [Required]
        public int Duration { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public int Price { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
