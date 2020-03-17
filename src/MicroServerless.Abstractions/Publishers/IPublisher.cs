using System.Threading.Tasks;

namespace Microservices.Abstractions.Publishers
{
    public interface IPublisher<TMessage> where TMessage : class
    {
        Task Publish(object message);
    }
}