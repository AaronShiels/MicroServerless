using System.Threading.Tasks;

namespace Microservices.Abstractions.Handlers
{
    public interface IEventHandler<TEvent> : IHandler<TEvent> where TEvent : class
    { }
}