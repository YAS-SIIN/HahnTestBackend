using System;

namespace HahnTestBackend.Domain.Commands.Employee
{
    public class UpdateEmployeeCommand : EmployeeCommandBase
    {
        public Guid Id { get; set; }
    }
}