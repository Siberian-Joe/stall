using catalog.DAL.Models;

namespace catalog.DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> Get()
        {
            return _context.categories;
        }

        public Category Get(int id)
        {
            return _context.categories.Find(id);
        }

        public void Create(Category category)
        {
            _context.categories.Add(category);
            _context.SaveChanges();
        }

        public void Update(Category updatedCategory)
        {
            Category currentCategory = Get(updatedCategory.Id);
            currentCategory.Title = updatedCategory.Title;

            _context.categories.Update(currentCategory);
            _context.SaveChanges();
        }

        public Category Delete(int id)
        {
            Category category = Get(id);

            if (category != null)
            {
                _context.categories.Remove(category);
                _context.SaveChanges();
            }

            return category;
        }
    }
}
