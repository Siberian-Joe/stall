using catalog.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace catalog.DAL.Repositories
{
    public class BrandRepository : Repository<Brand>
    {
        public BrandRepository(DataContext context) : base(context)
        {
        }

        protected override DbSet<Brand> GetData()
        {
            return _context.Brands;
        }
    }
}
