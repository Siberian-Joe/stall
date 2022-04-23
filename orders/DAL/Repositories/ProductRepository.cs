using orders.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace orders.DAL.Repositories
{
    public class ProductRepository : Repository<Product>
    {
        public ProductRepository(DataContext context) : base(context)
        {
        }

        public override void Create(Product item)
        {
            item.Category = _context.Categories.Find(item.Category.Id);
            item.Brand = _context.Brands.Find(item.Brand.Id);

            _context.Products.Add(item);
            _context.SaveChanges();
        }

        public override void Update(Product updatedItem)
        {
            Product currentItem = Get(updatedItem.Id);
            currentItem.Name = updatedItem.Name;
            currentItem.Description = updatedItem.Description;
            currentItem.Category = updatedItem.Category;
            currentItem.Brand = updatedItem.Brand;

            _context.Products.Update(currentItem);
            _context.SaveChanges();
        }

        public IEnumerable<Product> FindProductByTitle(string title)
        {
            return GetData().Where(item => item.Name == title);
        }

        protected override DbSet<Product> GetData()
        {
            return _context.Products;
        }
    }
}
