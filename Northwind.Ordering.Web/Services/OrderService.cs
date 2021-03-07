using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Northwind.Ordering.Web.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Northwind.Ordering.Web.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        private const string ORDER_SERVICE_URL = "OrderingService:Order";

        public OrderService(
            HttpClient httpClient,
            IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task AddOrderItem(OrderDetail orderDetail)
        {
            string address = _configuration[ORDER_SERVICE_URL] + "/addorderitem";
            StringContent content = new StringContent(
                JsonConvert.SerializeObject(orderDetail), System.Text.Encoding.UTF8, "application/json");
            await _httpClient.PostAsync(address, content);
        }

        public async Task<List<Order>> GetOrder()
        {
            string address = _configuration[ORDER_SERVICE_URL] + "/orders";
            string response = await _httpClient.GetStringAsync(address);
            return JsonConvert.DeserializeObject<List<Order>>(response);
        }

        public async Task<List<Product>> GetProducts()
        {
            string address = _configuration[ORDER_SERVICE_URL] + "/products";
            string response = await _httpClient.GetStringAsync(address);
            return JsonConvert.DeserializeObject<List<Product>>(response);
        }
    }
}
