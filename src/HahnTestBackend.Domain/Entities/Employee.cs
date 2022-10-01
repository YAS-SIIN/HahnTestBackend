using System.Collections.Generic;
using HahnTestBackend.Core.Entity;

namespace HahnTestBackend.Domain.Entities
{
    public class Employee : Entity
    {
        public string Name { get; set; } = "";
        public string SureName { get; set; } = "";
        public string NationalCode { get; set; } = "";
    }
}