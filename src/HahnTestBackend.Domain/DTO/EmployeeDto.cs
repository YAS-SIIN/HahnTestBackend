using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using HahnTestBackend.Core.Entity;

namespace HahnTestBackend.Domain.Entities
{
    public class EmployeeDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; private set; }

        [Required]
        [StringLength(100)]
        public string SureName { get; private set; }
                    
        [Required]
        [StringLength(10)]
        public string NationalCode { get; private set; }
    }
}