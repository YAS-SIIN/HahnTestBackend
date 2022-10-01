using System;
using HahnTestBackend.Core.Entity;
using HahnTestBackend.Core.Interfaces;
using HahnTestBackend.Infra.Data.Context;

namespace HahnTestBackend.Infra.Data.Repositories
{
    public class RepositoryBase<T> : IRepository<T> where T : IEntity
    {
        protected readonly myDBContext _HahnTestBackendContext;
        
        public RepositoryBase(myDBContext HahnTestBackendContext)
        {
            _HahnTestBackendContext = HahnTestBackendContext;
        }

        public int SaveChanges() => _HahnTestBackendContext.SaveChangesAsync().Result;

        public void Add(T entity) => _HahnTestBackendContext.Add(entity);     
        public void Update(T entity) => _HahnTestBackendContext.Update(entity);
         
        public void Dispose()
        {
            _HahnTestBackendContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
