using System.Threading.Tasks;

namespace Microservices.Abstractions.Handlers
{
    public interface IEventHandler<TEvent> where TEvent : class
    {
        Task Handle(TEvent @event);
    }
}