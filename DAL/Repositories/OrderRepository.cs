using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Entities;

namespace DAL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderPlatformContext _context;

        public OrderRepository(OrderPlatformContext context)
        {
            _context = context;
        }
        public void AddOrder(Order order)
        {
            if (order is null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            _context.Orders.Add(order);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _context.Orders.ToList();
        }

        public IEnumerable<Order> GetOrderByFilter(int start, int count, string status)
        {
            List<Order> items;

            if (status is null)
                items = _context.Orders.Skip(start - 1).Take(count).ToList();
            else
                items = _context.Orders.Where(o => o.Status == status).Skip(start - 1).Take(count).ToList();

            return items;
        }

        public Order GetOrderById(string id)
        {
            return _context.Orders.FirstOrDefault(o => o.Id == id);
        }
    }
}
