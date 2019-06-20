using System.Threading.Tasks;

namespace Microservices.Abstractions.Publishers
{
    public interface IPublisher
    {
        Task Publish(object @event);
    }
}