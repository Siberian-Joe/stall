using catalog.DAL.Models;

namespace catalog.DAL.Repositories
{
    public class BrandRepository : ICrudRepository<Brand>
    {
        private DataContext _context;

        public BrandRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Brand> Get()
        {
            return _context.Brands;
        }

        public Brand Get(int id)
        {
            return _context.Brands.Find(id);
        }

        public void Create(Brand item)
        {
            _context.Brands.Add(item);
            _context.SaveChanges();
        }

        public void Update(Brand updatedItem)
        {
            Brand currentItem = Get(updatedItem.Id);
            currentItem.Title = updatedItem.Title;

            _context.Brands.Update(currentItem);
            _context.SaveChanges();
        }

        public Brand Delete(int id)
        {
            Brand item = Get(id);

            if (item != null)
            {
                _context.Brands.Remove(item);
                _context.SaveChanges();
            }

            return item;
        }
    }
}
