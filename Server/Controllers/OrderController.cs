using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesManagementApp.Server.Interfaces;
using SalesManagementApp.Shared.Models;

namespace SalesManagementApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrders _orders;
        public OrderController(IOrders orders)
        {
            _orders = orders;
        }

        [HttpGet]
        public async Task<IActionResult> GetWindowAndElements()
        {
            var data = await _orders.GetOrderVM();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Orders orders = await _orders.GetOrder(id);
            if (orders != null)
            {
                return Ok(orders);
            }
            return NotFound();
        }

        [HttpPost]
        public void Post(Orders orders)
        {
            _orders.Add(orders);
        }

        [HttpPut]
        public void Put(Orders orders)
        {
            _orders.Update(orders);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _orders.Delete(id);
            return Ok();
        }
    }
}
