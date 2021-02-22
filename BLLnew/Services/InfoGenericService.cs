using AutoMapper;
using BLLnew.Interfaces;
using DALnew.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLLnew.Services
{
    public class InfoGenericService<TEntityDTO, TEntity> : IInfoGenericService<TEntityDTO, TEntity>
        where TEntityDTO : class
        where TEntity : class
    {
        private readonly IGenericRepository<TEntity> repository;
        protected readonly IMapper mapper;

        public InfoGenericService(IGenericRepository<TEntity> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public List<TEntityDTO> GetAll()
        {
            var entities = repository.GetAll().ToList();

            var entitiesDTO = mapper.Map<List<TEntityDTO>>(entities);

            return entitiesDTO;
        }

        public TEntityDTO GetById(int id)
        {
            var entity = repository.GetById(id);

            var entityDTO = mapper.Map<TEntityDTO>(entity);

            return entityDTO;
        }
    }
}
