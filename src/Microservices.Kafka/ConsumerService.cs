using System;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Microservices.Kafka
{
    public class ConsumerService : BackgroundService
    {
        private readonly ILogger<ConsumerService> _log;
        private readonly IOptionsMonitor<ConsumerOptions> _options;

        public ConsumerService(ILogger<ConsumerService> log, IOptionsMonitor<ConsumerOptions> options)
        {
            _log = log;
            _options = options;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var reloadStoppingToken = CancellationTokenSource.CreateLinkedTokenSource(stoppingToken);
            _options.OnChange(_options => reloadStoppingToken.Cancel());

            while (!stoppingToken.IsCancellationRequested)
            {
                using (var consumer = CreateConsumer())
                {
                    consumer.Subscribe(new[] { "topic" });
                    try
                    {
                        while (true)
                        {
                            try
                            {
                                var result = consumer.Consume(reloadStoppingToken.Token);
                            }
                            catch (ConsumeException consumeEx)
                            {

                            }
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        consumer.Close();
                        reloadStoppingToken = CancellationTokenSource.CreateLinkedTokenSource(stoppingToken);
                    }
                }
            }

            return Task.CompletedTask;
        }

        private IConsumer<Ignore, string> CreateConsumer()
        {
            return new ConsumerBuilder<Ignore, string>(_options.CurrentValue)
                .Build();
        }
    }
}