﻿using System.Collections.Generic;
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
            return await _HahnTestBackendContext.Employee.AnyAsync(a => a.NationalCode.Equals(nationalCode));
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _HahnTestBackendContext.Employee.AsNoTracking().ToListAsync();
        }

        public void Delete(Guid id)
        {
            var entity = _HahnTestBackendContext.Employee.FirstOrDefault(b => b.Id == id);
            _HahnTestBackendContext.Employee.Remove(entity);
        }

    }
}