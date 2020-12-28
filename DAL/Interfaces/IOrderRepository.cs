using System.Collections.Generic;
using DAL.Entities;

namespace DAL.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAllOrders();
        IEnumerable<Order> GetOrderByFilter(int start, int count, string status);
        Order GetOrderById(string id);
        void AddOrder(Order order);
    }
}
