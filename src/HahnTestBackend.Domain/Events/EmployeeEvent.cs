using HahnTestBackend.Core.Messages;

namespace HahnTestBackend.Domain.Events
{
    public class EmployeeEvent : Message
    {
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string NationalCode { get; set; }
    }
}
