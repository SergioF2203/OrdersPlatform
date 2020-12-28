using System.Collections.Generic;
using BLL.Models;

namespace BLL.Interfaces
{
    public interface IOrderService : ICrud<OrderModel>
    {
        IEnumerable<OrderModel> GetOrderByFilter(FilterModel filter);
    }
}
