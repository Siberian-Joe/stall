using catalog.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace catalog.DAL.Repositories
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
            currentItem.Title = updatedItem.Title;
            currentItem.Description = updatedItem.Description;
            currentItem.Category = updatedItem.Category;
            currentItem.Brand = updatedItem.Brand;

            _context.Products.Update(currentItem);
            _context.SaveChanges();
        }

        protected override DbSet<Product> GetData()
        {
            return _context.Products;
        }
    }
}
