using System.Threading.Tasks;
using Amazon.Lambda.RuntimeSupport;

namespace MicroServerless.Amazon.Lambda
{
    public interface ILambdaHandler
    {
        Task<InvocationResponse> HandleAsync(InvocationRequest invocation);
    }
}