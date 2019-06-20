using System.Threading.Tasks;
using Microservices.Sample.Domain;

namespace Microservices.Sample.Repository
{
    public interface IRepository
    {
        Task Add(Something thing);
        Task<Something> Query(int id);
    }
}