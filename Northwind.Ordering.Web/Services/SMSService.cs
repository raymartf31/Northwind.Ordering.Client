using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace Northwind.Ordering.Web.Services
{
    public class SMSService : ISMSService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public SMSService(
            HttpClient httpClient,
            IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task Send()
        {
            string address = _configuration["OrderingService:SMS"] + "/sendsms";
            await _httpClient.PostAsync(address, null);
        }
    }
}
