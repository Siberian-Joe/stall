using catalog.DAL.Models;

namespace catalog.DAL.Repositories
{
    public class ProductRepository : ICrudRepository<Product>
    {
        private DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> Get()
        {
            return _context.Products;
        }

        public Product Get(int id)
        {
            return _context.Products.Find(id);
        }

        public void Create(Product item)
        {
            item.Category = _context.Categories.Find(item.Category.Id);
            item.Brand = _context.Brands.Find(item.Brand.Id);

            _context.Products.Add(item);
            _context.SaveChanges();
        }

        public void Update(Product updatedItem)
        {
            Product currentItem = Get(updatedItem.Id);
            currentItem.Title = updatedItem.Title;
            currentItem.Description = updatedItem.Description;
            currentItem.Category = updatedItem.Category;
            currentItem.Brand = updatedItem.Brand;

            _context.Products.Update(currentItem);
            _context.SaveChanges();
        }

        public Product Delete(int id)
        {
            Product item = Get(id);

            if (item != null)
            {
                _context.Products.Remove(item);
                _context.SaveChanges();
            }

            return item;
        }
    }
}
