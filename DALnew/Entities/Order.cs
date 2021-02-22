using System;
using System.Collections.Generic;
using System.Text;

namespace DALnew.Entities
{
    public class Order
    {
        Object o;
        public int Id { get; set; }
        public decimal Sum { get; set; }
        public string PhoneNumer { get; set; }
        public int TourId { get; set; }
        public virtual Tour Tour { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
