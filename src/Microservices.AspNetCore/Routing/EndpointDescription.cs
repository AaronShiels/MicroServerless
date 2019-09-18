namespace Microservices.AspNetCore.Routing
{
    public class EndpointDescription
    {
        public EndpointDescription(string method, string path)
        {
            Method = method;
            Path = path;
        }

        public string Method { get; }
        public string Path { get; }
    }
}