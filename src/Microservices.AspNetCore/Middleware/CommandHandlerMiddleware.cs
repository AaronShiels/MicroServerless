using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microservices.Abstractions.Handlers;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Microservices.AspNetCore.Middleware
{
    public class CommandHandlerMiddleware<TCommand> : IMiddleware where TCommand : class
    {
        private readonly ICommandHandler<TCommand> _commandHandler;
        private readonly JsonSerializer _serializer;

        public CommandHandlerMiddleware(ICommandHandler<TCommand> commandHandler, JsonSerializer serializer)
        {
            _commandHandler = commandHandler;
            _serializer = serializer;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            string bodyContent;
            using (var streamReader = new StreamReader(context.Request.Body, Encoding.UTF8))
                bodyContent = await streamReader.ReadToEndAsync();

            var command = _serializer.DeserializeObject<TCommand>(bodyContent);

            var (success, details) = await _commandHandler.Handle(command);

            context.Response.StatusCode = success ? 200 : 400;
            context.Response.ContentType = "text/plain";
            await context.Response.WriteAsync(details);
        }
    }
}