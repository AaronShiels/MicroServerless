using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.RuntimeSupport;
using LambdaJsonSerializer = Amazon.Lambda.Serialization.Json.JsonSerializer;
using System;
using System.Threading.Tasks;

namespace MicroServerless.Sample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var entryPoint = new LambdaEntryPoint();
            var functionHandler = (Func<APIGatewayProxyRequest, ILambdaContext, Task<APIGatewayProxyResponse>>)entryPoint.HandleAsync;
            using var handlerWrapper = HandlerWrapper.GetHandlerWrapper(functionHandler, new LambdaJsonSerializer());
            using var bootstrap = new LambdaBootstrap(handlerWrapper);
            bootstrap.RunAsync().Wait();
        }
    }
}