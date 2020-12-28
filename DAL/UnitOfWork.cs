using DAL.Interfaces;
using DAL.Repositories;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OrderPlatformContext _context;

        private IOrderRepository orderRepository;

        public UnitOfWork(OrderPlatformContext context)
        {
            _context = context;
        }
        public IOrderRepository OrderRepository => orderRepository ?? new OrderRepository(_context);

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
