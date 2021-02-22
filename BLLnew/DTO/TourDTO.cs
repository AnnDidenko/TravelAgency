using System;
using System.Collections.Generic;
using System.Text;

namespace BLLnew.DTO
{
    public class TourDTO
    {
        public string Country { get; set; }
        public string DeparturePlace { get; set; }
        public DateTime DepartureDate { get; set; }
        public int Duration { get; set; }
        public int NumberOfPeople { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }
    }
}
