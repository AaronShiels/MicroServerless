using System.Threading.Tasks;

namespace Microservices.Abstractions.Publishers
{
    public interface IEventPublisher<TEvent> : IPublisher<TEvent> where TEvent : class
    { }
}