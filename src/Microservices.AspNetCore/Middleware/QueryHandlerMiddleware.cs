using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microservices.Abstractions.Handlers;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Microservices.AspNetCore.Middleware
{
    public class QueryHandlerMiddleware<TQuery, TResult> : IMiddleware where TQuery : class where TResult : class
    {
        private readonly IQueryHandler<TQuery, TResult> _queryHandler;
        private readonly JsonSerializer _serializer;

        public QueryHandlerMiddleware(IQueryHandler<TQuery, TResult> queryHandler, JsonSerializer serializer)
        {
            _queryHandler = queryHandler;
            _serializer = serializer;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            string bodyContent;
            using (var streamReader = new StreamReader(context.Request.Body, Encoding.UTF8))
                bodyContent = await streamReader.ReadToEndAsync();

            var query = _serializer.DeserializeObject<TQuery>(bodyContent);

            var result = await _queryHandler.Handle(query);

            var resultSerialized = _serializer.SerializeObject(result);

            context.Response.StatusCode = 200;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(resultSerialized);
        }
    }
}