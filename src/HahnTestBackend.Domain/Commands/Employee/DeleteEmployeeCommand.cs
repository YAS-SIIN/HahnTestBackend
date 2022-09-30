using System;
using HahnTestBackend.Core.Commands;

namespace HahnTestBackend.Domain.Commands.Employee
{
    public class DeleteEmployeeCommand : CommandBase
    {
        public Guid Id { get; set; }
    }
}