using System.Threading.Tasks;
using Microservices.Abstractions.Handlers;
using Microservices.Abstractions.Publishers;
using Microservices.Sample.Messages;

namespace Microservices.Sample.Handlers
{
    public class DoSomethingHandler : ICommandHandler<DoSomething>
    {
        private readonly IDomainEventPublisher _eventPublisher;
        private readonly IAnalyticEventPublisher _analyticsPublisher;

        public DoSomethingHandler(IDomainEventPublisher eventPublisher, IAnalyticEventPublisher analyticsPublisher)
        {
            _eventPublisher = eventPublisher;
            _analyticsPublisher = analyticsPublisher;
        }

        public async Task<(bool Success, string Details)> Handle(DoSomething command)
        {
            await _analyticsPublisher.Publish(new SomethingAttempted());

            var valid = Validate(command);
            if (!valid)
                return (false, "Shit's broke");

            await _eventPublisher.Publish(new SomethingHappened());
            return (true, string.Empty);
        }

        private static bool Validate(DoSomething command)
        {
            return true;
        }
    }
}