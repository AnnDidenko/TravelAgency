using DALnew.Context;
using DALnew.Entities;
using DALnew.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DALnew.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(OrderContext context)
            : base(context) { }
    }
}
