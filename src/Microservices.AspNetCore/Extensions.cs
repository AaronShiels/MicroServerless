using System;
using System.Collections.Generic;
using System.Linq;
using Microservices.Abstractions.Handlers;
using Microservices.AspNetCore.Routing;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Microservices.AspNetCore
{
    public static class Extensions
    {
        public static IServiceCollection AddHttpHandlers(this IServiceCollection services)
        {
            services.AddTransient<IEndpointResolver, ConventionRouteResolver>();
            services.AddTransient<IEnumerable<EndpointDescription>>(svc =>
            {
                var endpointResolver = svc.GetRequiredService<IEndpointResolver>();
                var handlerTypes = GetRegisteredHandlerTypes(services);

                return handlerTypes.Select(ht => endpointResolver.ResolveEndpoint(svc.GetRequiredService(ht)));
            });

            return services;
        }

        private static IEnumerable<Type> GetRegisteredHandlerTypes(IServiceCollection services) => services
            .Select(s => s.ServiceType)
            .Where(st => new[] { typeof(ICommandHandler<>), typeof(IQueryHandler<,>) }.Any(tt => st.GetGenericTypeDefinition() == tt));

        public static IApplicationBuilder UseHttpHandlers(this IApplicationBuilder app)
        {
            var endpointDescriptions = app.ApplicationServices.GetServices<EndpointDescription>();

            return app;
        }
    }
}