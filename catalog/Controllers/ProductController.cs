using catalog.DAL.Models;
using catalog.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace catalog.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        readonly private ICrudRepository<Product> _productRepository;

        public ProductController(ICrudRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet(Name = "GetAllProducts")]
        public IEnumerable<Product> Get()
        {
            return _productRepository.Get();
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult Get(int id)
        {
            Product product = _productRepository.Get(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            _productRepository.Create(product);
            return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Product updatedProduct)
        {
            if (updatedProduct == null || updatedProduct.Id != id)
                return BadRequest();

            Product product = _productRepository.Get(id);
            if (product == null)
                return NotFound();

            _productRepository.Update(updatedProduct);
            return RedirectToRoute("GetAllProducts");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productRepository.Delete(id);

            return RedirectToRoute("GetAllProducts");
        }
    }
}
