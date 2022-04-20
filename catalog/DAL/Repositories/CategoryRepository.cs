using catalog.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace catalog.DAL.Repositories
{
    public class CategoryRepository : Repository<Category>
    {
        public CategoryRepository(DataContext context) : base(context)
        {
        }

        protected override DbSet<Category> GetData()
        {
            return _context.Categories;
        }
    }
}
