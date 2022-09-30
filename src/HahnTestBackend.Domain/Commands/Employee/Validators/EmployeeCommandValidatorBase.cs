using FluentValidation;
using HahnTestBackend.Domain.Interfaces.Repositories;

namespace HahnTestBackend.Domain.Commands.Employee.Validators
{
    public abstract class EmployeeCommandValidatorBase<T>: AbstractValidator<T> where T : EmployeeCommandBase
    {
        private readonly IEmployeeRepository _EmployeeRepository;

        protected EmployeeCommandValidatorBase(IEmployeeRepository EmployeeRepository)
        {
            _EmployeeRepository = EmployeeRepository;
            ValidateNameIsUnique();
            ValidateName();
        }
        
        private void ValidateNameIsUnique()
        {
            RuleFor(EmployeeBaseCommand => EmployeeBaseCommand.Name)
                .MustAsync(async (nationalCode, cancellationToken) => !(await _EmployeeRepository.ExistsAsync(nationalCode)))
                .WithSeverity(Severity.Error)
                .WithMessage("A Employee with this name already exists.");
        }
        
        private void ValidateName()
        {
            RuleFor(EmployeeBaseCommand => EmployeeBaseCommand.Name)
                .Must(nationalCode => !string.IsNullOrWhiteSpace(nationalCode))
                .WithSeverity(Severity.Error)
                .WithMessage("Name can't be empty");
        }
    }
}