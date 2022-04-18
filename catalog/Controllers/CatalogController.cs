using catalog.DAL.Models;
using catalog.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace catalog.Controllers
{
    [Route("api/[controller]")]
    public class CatalogController : Controller
    {
        readonly private ICategoryRepository _categoryRepository;

        public CatalogController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = (CategoryRepository)categoryRepository;
        }

        [HttpGet(Name = "GetAllCategories")]
        public IEnumerable<Category> Get()
        {
            return _categoryRepository.Get();
        }

        [HttpGet("{id}", Name = "GetCategory")]
        public IActionResult Get(int id)
        {
            Category category = _categoryRepository.Get(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Category category)
        {
            if (category == null)
            {
                return BadRequest();
            }
            _categoryRepository.Create(category);
            return CreatedAtRoute("GetCategory", new { id = category.Id }, category);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Category updatedCategory)
        {
            if (updatedCategory == null || updatedCategory.Id != id)
                return BadRequest();

            Category category = _categoryRepository.Get(id);
            if (category == null)
                return NotFound();

            _categoryRepository.Update(updatedCategory);
            return RedirectToRoute("GetAllCategories");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _categoryRepository.Delete(id);

            return RedirectToRoute("GetAllCategories");
        }
    }
}