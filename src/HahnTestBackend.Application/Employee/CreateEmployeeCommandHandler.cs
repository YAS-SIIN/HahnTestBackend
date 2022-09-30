using FluentValidation;

using HahnTestBackend.Core.Commands;
using HahnTestBackend.Domain.Commands.Employee;

using HahnTestBackend.Application.AutoMapper;    
using HahnTestBackend.Core.Interfaces;      
using HahnTestBackend.Domain.Interfaces.Repositories;

namespace HahnTestBackend.Application.Employee
{
    public class CreateEmployeeCommandHandler : CommandHandlerBase, ICommandHandler<CreateEmployeeCommand>
    {
        private readonly IValidator<CreateEmployeeCommand> _createEmployeeCommandValidator;
        private readonly IEmployeeRepository _EmployeeRepository;

        public CreateEmployeeCommandHandler(IValidator<CreateEmployeeCommand> validator, IEmployeeRepository EmployeeRepository)
        {
            _createEmployeeCommandValidator = validator;
            _EmployeeRepository = EmployeeRepository;
        }

        public Result Handle(CreateEmployeeCommand command)
        {
            var validationResult = Validate(command, _createEmployeeCommandValidator);

            if (validationResult.IsValid)
            {
                var Employee = Mapper<Domain.Entities.Employee, CreateEmployeeCommand>.CommandToEntity(command);
                _EmployeeRepository.Add(Employee);
                _EmployeeRepository.SaveChanges();
            }

            return Return();
        }
    }
}