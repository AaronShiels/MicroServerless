using System.Threading.Tasks;
using Microservices.Abstractions.Handlers;
using Microservices.Sample.Messages;
using Microservices.Sample.Repository;

namespace Microservices.Sample.Handlers
{
    public class SomethingQueryHandler : IQueryHandler<SomethingQuery, SomethingResult>
    {
        private readonly IRepository _repo;

        public SomethingQueryHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<SomethingResult> Handle(SomethingQuery query)
        {
            var something = await _repo.Query(1);

            return new SomethingResult();
        }
    }
}