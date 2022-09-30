using System;
using HahnTestBackend.Core.Interfaces;
using HahnTestBackend.Domain.Events;

namespace HahnTestBackend.IoC
{
    public class ConsumerSubscriptions : IConsumerSubscriptions
    {
        private readonly IEventConsumer<EmployeeEvent, Guid> _EmployeeEventConsumer;
        private readonly IEventConsumer<DeleteEmployeeEvent, Guid> _deleteEmployeeEventConsumer;

        public ConsumerSubscriptions(
            IEventConsumer<EmployeeEvent, Guid> EmployeeEventConsumer,
            IEventConsumer<DeleteEmployeeEvent, Guid> deleteEmployeeEventConsumer)
        {
            _EmployeeEventConsumer = EmployeeEventConsumer;
            _deleteEmployeeEventConsumer = deleteEmployeeEventConsumer;
        }

        public void Subscribe()
        {
            _EmployeeEventConsumer.Subscribe();
            _deleteEmployeeEventConsumer.Subscribe();
        }

        public void Unsubscribe()
        {
            _EmployeeEventConsumer.Unsubscribe();
            _deleteEmployeeEventConsumer.Unsubscribe();
        }
    }

    public interface IConsumerSubscriptions
    {
        void Subscribe();
        void Unsubscribe();
    }
}
