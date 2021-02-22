using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Travel_agency.Models
{
    public class CreateTourRequestModel
    {
        [Required]
        public string Country { get; set; }
        [Required]
        public string DeparturePlace { get; set; }
        [Required]
        public DateTime DepartureDate { get; set; }
        [Required]
        public int Duration { get; set; }
        [Required]
        public int NumberOfPeople { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public int Price { get; set; }
    }
}
