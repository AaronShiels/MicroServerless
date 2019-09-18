namespace Microservices.AspNetCore.Routing
{
    public interface IEndpointResolver
    {
        EndpointDescription ResolveEndpoint<T>(T type) where T : class;
    }
}