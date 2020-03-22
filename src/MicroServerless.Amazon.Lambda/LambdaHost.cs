using System;
using System.Threading;
using System.Threading.Tasks;
using Amazon.Lambda.RuntimeSupport;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MicroServerless.Amazon.Lambda
{
    public class LambdaHost : IHost
    {
        private readonly ServiceProvider _services;
        private readonly LambdaBootstrap _bootstrap;

        public IServiceProvider Services => _services;

        internal LambdaHost(IServiceCollection serviceCollection)
        {
            _services = serviceCollection.BuildServiceProvider();

            var handler = _services.GetRequiredService<ILambdaHandler>();
            _bootstrap = new LambdaBootstrap(handler.HandleAsync);
        }

        public Task StartAsync(CancellationToken cancellationToken) => _bootstrap.RunAsync();


        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        public void Dispose()
        {
            _bootstrap.Dispose();
            _services.Dispose();
        }

        public static LambdaHostBuilder CreateDefaultBuilder() => new LambdaHostBuilder();
    }
}