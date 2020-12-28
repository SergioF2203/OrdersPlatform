using System;
using System.Collections.Generic;
using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork unitOfWOrk, IMapper mapper)
        {
            _unitOfWork = unitOfWOrk;
            _mapper = mapper;
        }

        public OrderModel Add(OrderModel model)
        {
            var item = _mapper.Map<OrderModel, Order>(model);

            var id = Guid.NewGuid().ToString();
            var status = "open";

            item.Id = id;
            item.Status = status;

            _unitOfWork.OrderRepository.AddOrder(item);

            if (!_unitOfWork.Save())
                return null;

            return _mapper.Map<Order, OrderResponse>(item);
        }

        public IEnumerable<OrderModel> GetAll()
        {
            var items = _unitOfWork.OrderRepository.GetAllOrders();

            return _mapper.Map<IEnumerable<Order>, IEnumerable<OrderResponse>>(items);
        }

        public OrderModel GetById(string id)
        {
            var item = _unitOfWork.OrderRepository.GetOrderById(id);

            return _mapper.Map<Order, OrderResponse>(item);
        }

        public IEnumerable<OrderModel> GetOrderByFilter(FilterModel filter)
        {
            var items = _unitOfWork.OrderRepository.GetOrderByFilter(filter.Start, filter.Quantity, filter.Status);

            return _mapper.Map<IEnumerable<Order>, IEnumerable<OrderResponse>>(items);
        }
    }
}
