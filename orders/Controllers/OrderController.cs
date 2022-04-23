using orders.DAL.Models;
using orders.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace orders.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        readonly private OrderRepository _orderRepository;

        public OrderController(OrderRepository OrderRepository)
        {
            _orderRepository = OrderRepository;
        }

        [HttpGet(Name = "GetAllOrders")]
        public IEnumerable<Order> Get()
        {
            return _orderRepository.Get();
        }

        [HttpGet("{id}", Name = "GetOrder")]
        public IActionResult Get(int id)
        {
            Order order = _orderRepository.Get(id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Order order)
        {
            if (order == null)
            {
                return BadRequest();
            }
            _orderRepository.Create(order);
            return CreatedAtRoute("GetOrder", new { id = order.Id }, order);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _orderRepository.Delete(id);

            return RedirectToRoute("GetAllOrders");
        }
    }
}
