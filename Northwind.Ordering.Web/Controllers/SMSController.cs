using Microsoft.AspNetCore.Mvc;
using Northwind.Ordering.Web.Services;
using System;
using System.Threading.Tasks;

namespace Northwind.Ordering.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMSController : ControllerBase
    {
        private readonly ISMSService _SMSService;

        public SMSController(ISMSService smsService)
        {
            _SMSService = smsService;
        }

        [HttpPost("sms")]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                await _SMSService.Send();
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
