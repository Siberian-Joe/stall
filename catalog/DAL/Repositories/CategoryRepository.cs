using catalog.DAL.Models;

namespace catalog.DAL.Repositories
{
    public class CategoryRepository : ICrudRepository<Category>
    {
        private DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> Get()
        {
            return _context.Categories;
        }

        public Category Get(int id)
        {
            return _context.Categories.Find(id);
        }

        public void Create(Category item)
        {
            _context.Categories.Add(item);
            _context.SaveChanges();
        }

        public void Update(Category updatedItem)
        {
            Category currentItem = Get(updatedItem.Id);
            currentItem.Title = updatedItem.Title;

            _context.Categories.Update(currentItem);
            _context.SaveChanges();
        }

        public Category Delete(int id)
        {
            Category item = Get(id);

            if (item != null)
            {
                _context.Categories.Remove(item);
                _context.SaveChanges();
            }

            return item;
        }
    }
}
