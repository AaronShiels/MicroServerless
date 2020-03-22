using System.Threading.Tasks;
using MicroServerless.Amazon.Lambda;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MicroServerless.Sample
{
    public class Program
    {
        public static Task Main(string[] args) => CreateHostBuilder(args).Build().StartAsync();

        public static IHostBuilder CreateHostBuilder(string[] args) => LambdaHost
            .CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddSingleton<ILambdaHandler, ApiGatewayHandler>();
            });
    }
}