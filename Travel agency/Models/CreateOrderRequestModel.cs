using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Travel_agency.Models
{
    public class CreateOrderRequestModel
    {
        [Required]
        public decimal Sum { get; set; }
        [Required]
        public int TourId { get; set; }
        [Required]
        public string PhoneNumer { get; set; }
    }
}
