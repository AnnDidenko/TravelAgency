using DALnew.Context;
using DALnew.Entities;
using DALnew.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DALnew.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly OrderContext dbContext;

        private IGenericRepository<Tour> tours;
        private IGenericRepository<Order> orders;

        public UnitOfWork(OrderContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            return new GenericRepository<T>(dbContext);
        }

        public IGenericRepository<Tour> Tours
        {
            get
            {
                if (tours == null)
                    tours = GetRepository<Tour>();

                return tours;
            }
        }

        public IGenericRepository<Order> Orders
        {
            get
            {
                if (orders == null)
                    orders = GetRepository<Order>();

                return orders;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
                disposed = true;
            }
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}
