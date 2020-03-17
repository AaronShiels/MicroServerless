using System.Threading.Tasks;

namespace Microservices.Abstractions.Handlers
{
    public interface IQueryHandler<TQuery, TResult> : IHandler<TQuery, TResult> where TQuery : class where TResult : class
    { }
}