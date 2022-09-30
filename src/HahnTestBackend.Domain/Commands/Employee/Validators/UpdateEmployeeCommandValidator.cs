using System;
using FluentValidation;
using HahnTestBackend.Domain.Interfaces.Repositories;

namespace HahnTestBackend.Domain.Commands.Employee.Validators
{
    public class UpdateEmployeeCommandValidator : EmployeeCommandValidatorBase<UpdateEmployeeCommand>
    {
        public UpdateEmployeeCommandValidator(IEmployeeRepository EmployeeRepository)
            : base(EmployeeRepository)
        {
            ValidateId();
        }

        private void ValidateId()
        {
            RuleFor(updateEmployeeCommand => updateEmployeeCommand.Id)
                .Must(id => !id.Equals(Guid.Empty))
                .WithSeverity(Severity.Error)
                .WithMessage("Id can't be empty");
        }
    }
}