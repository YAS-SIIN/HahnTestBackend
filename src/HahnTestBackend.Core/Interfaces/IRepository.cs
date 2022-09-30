using System;
using System.Threading.Tasks;
using HahnTestBackend.Core.Entity;

namespace HahnTestBackend.Core.Interfaces
{
    public interface IRepository<in T> : IDisposable where T : IEntity
    {
        int SaveChanges();
        void Add(T entity);
        void Update(T entity);
    }
}
