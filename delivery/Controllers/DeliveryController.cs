using delivery.DAL.Models;
using delivery.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace delivery.Controllers
{
    [Route("api/[controller]")]
    public class DeliveryController : Controller
    {
        readonly private DeliveryRepository _deliveryRepository;

        public DeliveryController(DeliveryRepository productRepository)
        {
            _deliveryRepository = productRepository;
        }

        [HttpGet(Name = "GetAllDeliveries")]
        public IEnumerable<Delivery> Get()
        {
            return _deliveryRepository.Get();
        }

        [HttpGet("{id}", Name = "GetDelivery")]
        public IActionResult Get(int id)
        {
            Delivery delivery = _deliveryRepository.Get(id);

            if (delivery == null)
            {
                return NotFound();
            }

            return Ok(delivery);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Delivery delivery)
        {
            if (delivery == null)
            {
                return BadRequest();
            }
            _deliveryRepository.Create(delivery);
            return CreatedAtRoute("GetDelivery", new { id = delivery.Id }, delivery);
        }

        [Route("registrationOrder")]
        [HttpPost]
        public IActionResult RegistrationOrderInDelivery([FromBody] Order order)
        {
            if (order == null)
            {
                return BadRequest();
            }
            _deliveryRepository.RegistrationOrderInDelivery(order);
            return Ok(order);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _deliveryRepository.Delete(id);

            return RedirectToRoute("GetAllDeliveries");
        }
    }
}
