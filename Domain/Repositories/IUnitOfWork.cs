using System.Threading.Tasks;

namespace SuperMarket.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}