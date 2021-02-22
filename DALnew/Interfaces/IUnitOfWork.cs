using DALnew.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DALnew.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IGenericRepository<Tour> Tours { get; }
        IGenericRepository<Order> Orders { get; }
        void Save();
    }
}
