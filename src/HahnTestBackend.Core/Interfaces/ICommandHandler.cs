using HahnTestBackend.Core.Commands;

namespace HahnTestBackend.Core.Interfaces
{
    public interface ICommandHandler<in T>  where T : CommandBase
    {
        Result Handle(T command);
    }
}