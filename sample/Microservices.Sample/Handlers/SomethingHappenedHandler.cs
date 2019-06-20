using System.Threading.Tasks;
using Microservices.Abstractions.Handlers;
using Microservices.Sample.Domain;
using Microservices.Sample.Messages;
using Microservices.Sample.Repository;

namespace Microservices.Sample
{
    public class SomethingHappenedHandler : IEventHandler<SomethingHappened>
    {
        private readonly IRepository _repo;

        public SomethingHappenedHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task Handle(SomethingHappened @event)
        {
            await _repo.Add(new Something());
        }
    }
}