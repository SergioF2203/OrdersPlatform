using DAL.Repositories;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IOrderRepository OrderRepository { get; }

        bool Save();
    }
}
