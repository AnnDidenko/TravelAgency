using DALnew.Context;
using DALnew.Entities;
using DALnew.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DALnew.Repositories
{
    public class TourRepository : GenericRepository<Tour>, ITourRepository
    {
        public TourRepository(OrderContext context)
            : base(context) { }
    }
}
