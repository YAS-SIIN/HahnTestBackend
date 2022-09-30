using System.Collections.Generic;
using System.Threading.Tasks;
using HahnTestBackend.Domain.Interfaces.Repositories;

namespace HahnTestBackend.Application.Employee
{
    public class EmployeeQueries : IEmployeeQueries
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeQueries(IEmployeeRepository EmployeeRepository)
        {
            _employeeRepository = EmployeeRepository;
        }

        public async Task<IEnumerable<Domain.Entities.Employee>> GetAllAsync()
        {
            return await _employeeRepository.GetAllAsync();
        }
         
    }

    public interface IEmployeeQueries
    {
        Task<IEnumerable<Domain.Entities.Employee>> GetAllAsync();
    }
}