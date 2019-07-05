using System.Threading.Tasks;

namespace Microservices.Abstractions.Publishers
{
    public interface IEventPublisher
    {
        Task Publish(object @event);
    }
}