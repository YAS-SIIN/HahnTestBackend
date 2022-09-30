using HahnTestBackend.Domain.Interfaces.Repositories;

namespace HahnTestBackend.Domain.Commands.Employee.Validators
{
    public class CreateEmployeeCommandValidator : EmployeeCommandValidatorBase<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidator(IEmployeeRepository EmployeeRepository)
            : base((EmployeeRepository))
        {
        }
    }
}