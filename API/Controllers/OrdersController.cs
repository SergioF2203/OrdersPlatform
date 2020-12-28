using System.Collections.Generic;
using System.Linq;
using API.Models;
using BLL.Interfaces;
using BLL.Models;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _repository;
        private readonly IOrderService _orderService;

        public OrdersController(IOrderRepository repository, IOrderService orderService)
        {
            _repository = repository;

            _orderService = orderService;
        }
        // GET api/orders
        [HttpGet]
        public ActionResult<IEnumerable<OrderResponse>> GetAllOrder(int start, int quantity, string status)
        {
            if (start == 0 && quantity == 0 && status is null)
            {
                return GetAll();
            }

            return GetOrdersByFilter(start, quantity, status);

        }

        // GET api/orders/{id}
        [HttpGet("{id}", Name = "GetOrderById")]
        public ActionResult<OrderResponse> GetOrderById(string id)
        {
            var orderItem = _orderService.GetById(id);

            if (orderItem is null)
                return NotFound(new ErrorModel
                {
                    Code = 135,
                    Message = "Order not found",
                    Details = $"Cannot find order with id: {id}"
                });

            return Ok(orderItem);
        }

        // POST api/orders
        [HttpPost]
        public ActionResult<OrderResponse> AddOrder(OrderRequest order)
        {
            if (order is null)
                return BadRequest();

            if (order.Pickup is null || order.Dropoff is null)
                ModelState.AddModelError("Location", "Invalid location field in incoming object");

            if (!ModelState.IsValid)
                return UnprocessableEntity(new ErrorModel()
                {
                    Code = 1050,
                    Message = "Invalid data",
                    Details = "Invalid location field in incoming object"
                });

            var item = _orderService.Add(order);

            return CreatedAtRoute(nameof(GetOrderById), new { id = item.Id }, item);
        }

        private ActionResult<IEnumerable<OrderResponse>> GetAll()
        {
            var orderItems = _orderService.GetAll();

            return Ok(orderItems);
        }

        private ActionResult<IEnumerable<OrderResponse>> GetOrdersByFilter(int start, int quantity, string status)
        {
            if ((start < 1 || quantity < 1) && status is null)
                return NoContent();

            FilterModel filterModel;

            if (start < 1 && quantity < 1)
                filterModel = new FilterModel() { Status = status };
            else if (start < 1)
                filterModel = new FilterModel() { Quantity = quantity, Status = status };
            else if (quantity < 1)
                filterModel = new FilterModel() { Start = start, Status = status };
            else
                filterModel = new FilterModel
                {
                    Start = start,
                    Quantity = quantity,
                    Status = status
                };

            var orderItems = _orderService.GetOrderByFilter(filterModel);

            if (!orderItems.Any())
                return NoContent();

            return Ok(orderItems);
        }
    }
}
