using System.Threading.Tasks;
using BuyFood.Domain.Interfaces;

namespace BuyFood.Domain.Services
{
    public class BaseService
    {
        private readonly IUnitOfWork _uow;

        public BaseService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void BeginTransaction()
        {
            _uow.BeginTransaction();
        }

        public void Commit()
        {
            _uow.Commit();
        }

        public Task<int> CommitAsync()
        {
            return _uow.CommitAsync();
        }
    }
}
