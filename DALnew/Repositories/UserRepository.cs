using DALnew.Context;
using DALnew.Entities;
using DALnew.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DALnew.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(OrderContext context)
            : base(context) { }
    }
}
