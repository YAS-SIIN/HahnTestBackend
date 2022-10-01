using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HahnTestBackend.Domain.Entities;
using HahnTestBackend.Domain.Interfaces.Repositories;
using HahnTestBackend.Infra.Data.Context;

namespace HahnTestBackend.Infra.Data.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(myDBContext context)
            : base(context)
        {
        }

        public async Task<bool> ExistsAsync(string nationalCode)
        {
            return await _HahnTestBackendContext.Employees.AnyAsync(a => a.NationalCode.Equals(nationalCode));
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _HahnTestBackendContext.Employees.AsNoTracking().ToListAsync();
        }

        public void Delete(int Id)
        {
            var entity = _HahnTestBackendContext.Employees.Find(Id);
            _HahnTestBackendContext.Employees.Remove(entity);
        }

    }
}