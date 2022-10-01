using System.Collections.Generic;
using System.Threading.Tasks;
using HahnTestBackend.Core.Interfaces;
using HahnTestBackend.Domain.Entities;

namespace HahnTestBackend.Domain.Interfaces.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<bool> ExistsAsync(string nationalCode);
        Task<IEnumerable<Employee>> GetAllAsync();
        void Delete(int Id);
    }
}