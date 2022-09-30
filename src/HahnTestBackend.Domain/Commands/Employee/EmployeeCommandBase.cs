using HahnTestBackend.Core.Commands;

using System.ComponentModel.DataAnnotations;

namespace HahnTestBackend.Domain.Commands.Employee
{
    public abstract class EmployeeCommandBase : CommandBase
    {
        [Required]
        [StringLength(100)]
        public string Name { get;  set; }
        [StringLength(100)]
        public string SureName { get; private set; }
        [StringLength(10)]
        public string NationalCode { get; private set; }
    }
}