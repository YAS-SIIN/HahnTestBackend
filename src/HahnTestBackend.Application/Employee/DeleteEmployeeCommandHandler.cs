using FluentValidation;
using HahnTestBackend.Core.Commands;
using HahnTestBackend.Core.Interfaces;
using HahnTestBackend.Domain.Commands.Employee;
using HahnTestBackend.Domain.Commands.Employee.Validators;
using HahnTestBackend.Domain.Events;
using HahnTestBackend.Domain.Interfaces.Repositories;

namespace HahnTestBackend.Application.Employee
{
    public class DeleteEmployeeCommandHandler : CommandHandlerBase, ICommandHandler<DeleteEmployeeCommand>
    {
        private readonly IValidator<DeleteEmployeeCommand> _deleteEmployeeCommandValidator;
        private readonly IEmployeeRepository _EmployeeRepository;
        private readonly IEventPublisher<DeleteEmployeeEvent> _eventPublisher;

        public DeleteEmployeeCommandHandler(
            IValidator<DeleteEmployeeCommand> deleteEmployeeCommandValidator, 
            IEmployeeRepository EmployeeRepository, 
            IEventPublisher<DeleteEmployeeEvent> eventPublisher)
        {
            _deleteEmployeeCommandValidator = deleteEmployeeCommandValidator;
            _EmployeeRepository = EmployeeRepository;
            _eventPublisher = eventPublisher;
        }

        public Result Handle(DeleteEmployeeCommand command)
        {
            var validationResult = Validate(command, _deleteEmployeeCommandValidator);

            if (validationResult.IsValid)
            {
                _EmployeeRepository.Delete(command.Id);
                _EmployeeRepository.SaveChanges();

                _eventPublisher.Publish(new DeleteEmployeeEvent { Id = command.Id});
            }

            return Return();
        }
    }
}