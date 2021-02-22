using System;
using System.Collections.Generic;
using System.Text;

namespace BLLnew.Interfaces
{
    public interface IInfoGenericService<TEntityDTO, TEntity>
        where TEntityDTO : class
        where TEntity : class
    {
        TEntityDTO GetById(int id);
        List<TEntityDTO> GetAll();
    }
}
