using HahnTestBackend.Core.Commands;

namespace HahnTestBackend.Domain.Commands.Employee
{
    public abstract class EmployeeCommandBase : CommandBase
    {
        public string Name { get;  set; }
    }
}