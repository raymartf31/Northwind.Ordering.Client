using Northwind.Ordering.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Northwind.Ordering.Web.Services
{
    public interface IOrderService
    {
        Task<List<Order>> GetOrder();

        Task<List<Product>> GetProducts();

        Task AddOrderItem(OrderDetail orderDetail);
    }
}
