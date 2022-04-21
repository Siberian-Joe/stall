using catalog.DAL.Models;
using catalog.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace catalog.Controllers
{
    [Route("api/[controller]")]
    public class BrandController : Controller
    {
        readonly private BrandRepository _brandRepository;

        public BrandController(BrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        [HttpGet(Name = "GetAllBrands")]
        public IEnumerable<Brand> Get()
        {
            return _brandRepository.Get();
        }

        [HttpGet("{id}", Name = "GetBrand")]
        public IActionResult Get(int id)
        {
            Brand brand = _brandRepository.Get(id);

            if (brand == null)
            {
                return NotFound();
            }

            return Ok(brand);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Brand brand)
        {
            if (brand == null)
            {
                return BadRequest();
            }
            _brandRepository.Create(brand);
            return CreatedAtRoute("GetBrand", new { id = brand.Id }, brand);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Brand updatedBrand)
        {
            if (updatedBrand == null || updatedBrand.Id != id)
                return BadRequest();

            Brand brand = _brandRepository.Get(id);
            if (brand == null)
                return NotFound();

            _brandRepository.Update(updatedBrand);
            return RedirectToRoute("GetAllBrands");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _brandRepository.Delete(id);

            return RedirectToRoute("GetAllBrands");
        }
    }
}
