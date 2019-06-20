using System.Threading.Tasks;

namespace Microservices.Abstractions.Handlers
{
    public interface IQueryHandler<TQuery, TResult> where TQuery : class where TResult : class
    {
        Task<TResult> Handle(TQuery query);
    }
}