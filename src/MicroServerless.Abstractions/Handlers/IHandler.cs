using System.Threading.Tasks;

namespace Microservices.Abstractions.Handlers
{
    public interface IHandler<TMessage> where TMessage : class
    {
        Task Handle(TMessage message);
    }

    public interface IHandler<TInput,TOutput> where TInput:class where TOutput:class
    {
        Task<TOutput> Handle(TInput message);
    }
}