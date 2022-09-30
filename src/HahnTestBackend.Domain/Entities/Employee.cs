using System.Collections.Generic;
using HahnTestBackend.Core.Entity;

namespace HahnTestBackend.Domain.Entities
{
    public class Employee : Entity
    {
        public Employee(string name, string sureName, string nationalCode)
        {
            Name = name;
            SureName = sureName;
            NationalCode = nationalCode;
        }

        public string Name { get; private set; }
        public string SureName { get; private set; }
        public string NationalCode { get; private set; }
    }
}