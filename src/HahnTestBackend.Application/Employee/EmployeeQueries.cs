using System.Collections.Generic;
using System.Threading.Tasks;
using HahnTestBackend.Domain.Interfaces.Repositories;

namespace HahnTestBackend.Application.Employee
{
    public class EmployeeQueries : IEmployeeQueries
    {
        private readonly IEmployeeRepository _EmployeeRepository;

        public EmployeeQueries(IEmployeeRepository EmployeeRepository)
        {
            _EmployeeRepository = EmployeeRepository;
        }

        public async Task<IEnumerable<Domain.Entities.Employee>> GetAllAsync()
        {
            return await _EmployeeRepository.GetAllAsync();
        }
    }

    public interface IEmployeeQueries
    {
        Task<IEnumerable<Domain.Entities.Employee>> GetAllAsync();
    }
}