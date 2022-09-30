using System;

namespace HahnTestBackend.Core.Messages
{
    public abstract class Message : IMessage<Guid>
    {
        public Guid Id { get; set; }

        public Message()
        {
            Id = Guid.NewGuid();
        }
    }
}
