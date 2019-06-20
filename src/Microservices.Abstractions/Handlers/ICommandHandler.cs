using System.Threading.Tasks;

namespace Microservices.Abstractions.Handlers
{
    public interface ICommandHandler<TCommand> where TCommand : class
    {
        Task<(bool Success, string Details)> Handle(TCommand command);
    }
}