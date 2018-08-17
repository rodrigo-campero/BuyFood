using System.Threading.Tasks;

namespace BuyFood.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
        Task<int> CommitAsync();
    }
}
