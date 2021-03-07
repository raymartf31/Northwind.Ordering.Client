using Microsoft.AspNetCore.Mvc;
using Northwind.Ordering.Web.Models;
using Northwind.Ordering.Web.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Northwind.Ordering.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("products")]
        public async Task<IActionResult> GetProducts()
        {
            List<Product> results;

            try
            {
                results = await _orderService.GetProducts();
            }
            catch (Exception ex)
            {
                // log exception.
                return BadRequest();
            }

            return Ok(results);
        }

        [HttpGet("order")]
        public async Task<IActionResult> GetOrder()
        {
            List<Order> results = new List<Order>();

            try
            {
                List<Order> orders = await _orderService.GetOrder();

                foreach (Order order in orders)
                {
                    Order result = new Order
                    {
                        OrderID = order.OrderID,
                        OrderDate = order.OrderDate,
                        OrderDetails = new List<OrderDetail>()
                    };

                    foreach (var orderDetail in order.OrderDetails)
                    {
                        result.OrderDetails.Add(new OrderDetail {
                            OrderID = orderDetail.OrderID,
                            Product = orderDetail.Product,
                            Quantity = orderDetail.Quantity,
                            UnitPrice = orderDetail.Quantity * orderDetail.UnitPrice
                        });
                    }

                    results.Add(result);
                }
            }
            catch (Exception ex)
            {
                // log exception.
                return BadRequest();
            }
            
            return Ok(results);
        }

        [HttpPost("addorderitem")]
        public async Task<IActionResult> AddOrderItem(OrderDetail orderDetail)
        {
            try
            {
                await _orderService.AddOrderItem(orderDetail);
            }
            catch (Exception ex)
            {
                // log exception.
                return BadRequest();
            }

            return Ok();
        }
    }
}
