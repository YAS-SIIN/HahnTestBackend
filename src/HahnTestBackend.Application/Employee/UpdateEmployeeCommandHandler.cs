using FluentValidation;
using HahnTestBackend.Application.AutoMapper;
using HahnTestBackend.Core.Commands;
using HahnTestBackend.Core.Interfaces;
using HahnTestBackend.Domain.Commands.Employee;
using HahnTestBackend.Domain.Interfaces.Repositories;

namespace HahnTestBackend.Application.Employee
{
    public class UpdateEmployeeCommandHandler: CommandHandlerBase,  ICommandHandler<UpdateEmployeeCommand>
    {
        private readonly IValidator<UpdateEmployeeCommand> _createEmployeeCommandValidator;
        private readonly IEmployeeRepository _EmployeeRepository;
        
        public UpdateEmployeeCommandHandler(IValidator<UpdateEmployeeCommand> validator, IEmployeeRepository EmployeeRepository)
        {
            _createEmployeeCommandValidator = validator;
            _EmployeeRepository = EmployeeRepository;
        }

        public Result Handle(UpdateEmployeeCommand command)
        {
            var validationResult = Validate(command, _createEmployeeCommandValidator);

            if (validationResult.IsValid)
            {
                var Employee = Mapper<Domain.Entities.Employee, UpdateEmployeeCommand>.CommandToEntity(command);
                _EmployeeRepository.Update(Employee);
                _EmployeeRepository.SaveChanges();
            }

            return Return();
        }
    }
}