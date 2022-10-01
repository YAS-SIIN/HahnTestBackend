using FluentValidation;

using HahnTestBackend.Domain.Entities;
using HahnTestBackend.Domain.Interfaces.Repositories;

namespace HahnTestBackend.Domain.Validators
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(customer => customer.SureName).NotNull().NotEqual("foo");
            ValidateName();
            ValidateSureName();
            ValidateNationalCode();
        }

        private void ValidateName()
        {
            RuleFor(EmployeeData => EmployeeData.Name)
                .Must(name => !string.IsNullOrWhiteSpace(name))
                .WithSeverity(Severity.Error)
                .WithMessage("Name can't be empty");
        }
        private void ValidateSureName()
        {
            RuleFor(EmployeeData => EmployeeData.SureName)
                .Must(sureName => !string.IsNullOrWhiteSpace(sureName))
                .WithSeverity(Severity.Error)
                .WithMessage("SureName can't be empty");
        }

        private void ValidateNationalCode()
        {
            RuleFor(EmployeeData => EmployeeData.NationalCode)
                .Must(nationalCode => !string.IsNullOrWhiteSpace(nationalCode))
                .WithSeverity(Severity.Error)
                .WithMessage("NationalCode can't be empty");
        }

    }                            
}