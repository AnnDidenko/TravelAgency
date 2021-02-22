using DALnew.Context;
using DALnew.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DALnew.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly OrderContext dbContext;
        protected readonly DbSet<TEntity> entities;

        public GenericRepository(OrderContext dbContext)
        {
            this.dbContext = dbContext;
            entities = dbContext.Set<TEntity>();
        }


        public void Add(TEntity entity)
        {
            entities.Add(entity);
            dbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            entities.Update(entity);
            dbContext.SaveChanges();
        }

        public void Remove(int id)
        {
            var entity = GetById(id);
            entities.Remove(entity);
            dbContext.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return entities;
        }


        public TEntity GetById(int id)
        {
            return entities.Find(id);
        }

    }
}
