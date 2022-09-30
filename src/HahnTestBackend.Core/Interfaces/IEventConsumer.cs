using Microsoft.Extensions.Hosting;
using HahnTestBackend.Core.Messages;

namespace HahnTestBackend.Core.Interfaces
{
    public interface IEventConsumer<TMessage, TPrimaryKey>
        where TMessage : class, IMessage<TPrimaryKey>
    {
        void Subscribe();
        void Unsubscribe();
    }
}
