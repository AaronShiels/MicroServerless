using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.RuntimeSupport;
using Microsoft.Extensions.DependencyInjection;

namespace MicroServerless.Amazon.Lambda
{
    public class ApiGatewayHandler : ILambdaHandler
    {
        private readonly MemoryStream _responseStream = new MemoryStream();
        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

        private readonly IServiceScopeFactory _serviceScopeFactory;

        public ApiGatewayHandler(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task<InvocationResponse> HandleAsync(InvocationRequest invocation)
        {
            var payload = await JsonSerializer.DeserializeAsync<APIGatewayProxyRequest>(invocation.InputStream);
            var context = invocation.LambdaContext;

            var httpResponse = new APIGatewayProxyResponse
            {
                StatusCode = 200,
                Body = "Hello"
            };

            _responseStream.SetLength(0);
            await JsonSerializer.SerializeAsync(_responseStream, httpResponse, _jsonOptions);
            _responseStream.Position = 0;
            return new InvocationResponse(_responseStream, false);
        }
    }
}