using System;
using System.Collections.Generic;
using System.Text;

namespace DALnew.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        void Update(TEntity entity);

        void Remove(int id);

        IEnumerable<TEntity> GetAll();

        TEntity GetById(int id);
    }
}
