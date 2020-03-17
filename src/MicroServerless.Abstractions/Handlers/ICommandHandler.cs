using System.Threading.Tasks;

namespace Microservices.Abstractions.Handlers
{
    public interface ICommandHandler<TCommand> : IHandler<TCommand> where TCommand : class
    { }
}