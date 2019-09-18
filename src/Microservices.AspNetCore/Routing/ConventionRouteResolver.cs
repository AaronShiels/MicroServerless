using System;
using System.Collections.Generic;
using System.Linq;
using Microservices.Abstractions.Handlers;

namespace Microservices.AspNetCore.Routing
{
    public class ConventionRouteResolver : IEndpointResolver
    {
        private const string BaseSegment = "api";
        private static readonly IEnumerable<string> ReservedWords = new[] { "command", "query", "event", "handler" };

        public EndpointDescription ResolveEndpoint<T>(T handler) where T : class
        {
            var type = typeof(T);

            string method;
            if (type.IsAssignableFrom(typeof(ICommandHandler<>)))
                method = "POST";
            else if (type.IsAssignableFrom(typeof(IQueryHandler<,>)))
                method = "GET";
            else
                throw new ArgumentOutOfRangeException($"{type.Name} is not a known handler type.");

            var namedSegment = ReservedWords.Aggregate(type.Name.ToLowerInvariant(), (accum, currWord) => accum.Replace(currWord, string.Empty));
            var path = $"/{BaseSegment}/{namedSegment}";

            return new EndpointDescription(method, path);
        }
    }
}