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
            ValidateNationalCodeIsUnique();
            ValidateName();
            ValidateSureName();
            ValidateNationalCode();
        }
        
        private void ValidateNationalCodeIsUnique()
        {
            RuleFor(EmployeeBaseCommand => EmployeeBaseCommand.NationalCode)
                .MustAsync(async (nationalCode, cancellationToken) => !(await _EmployeeRepository.ExistsAsync(nationalCode)))
                .WithSeverity(Severity.Error)
                .WithMessage("A Employee with this NationalCode already exists.");
        }
        
        private void ValidateName()
        {
            RuleFor(EmployeeBaseCommand => EmployeeBaseCommand.Name)
                .Must(name => !string.IsNullOrWhiteSpace(name))
                .WithSeverity(Severity.Error)
                .WithMessage("Name can't be empty");
        }

        private void ValidateSureName()
        {
            RuleFor(EmployeeBaseCommand => EmployeeBaseCommand.SureName)
                .Must(sureName => !string.IsNullOrWhiteSpace(sureName))
                .WithSeverity(Severity.Error)
                .WithMessage("Name can't be empty");
        }

        private void ValidateNationalCode()
        {
            RuleFor(EmployeeBaseCommand => EmployeeBaseCommand.NationalCode)
                .Must(nationalCode => !string.IsNullOrWhiteSpace(nationalCode))
                .WithSeverity(Severity.Error)
                .WithMessage("Name can't be empty");
        }

    }
}