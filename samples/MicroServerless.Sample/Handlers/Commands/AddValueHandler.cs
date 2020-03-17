using Amazon.Lambda.Core;
using MicroServerless.Sample.Handlers.Commands.Models;
using MicroServerless.Sample.Handlers.Events.Models;
using System.Threading.Tasks;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
namespace MicroServerless.Sample.Handlers.Commands
{
    public class AddValueHandler
    {
        public async Task<ValueAdded> HandleAsync(AddValue request)
        {
            return new ValueAdded
            {
                Key = request.Key,
                Value = request.Value
            };
        }
    }
}
