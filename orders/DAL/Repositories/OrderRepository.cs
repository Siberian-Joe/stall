using Microsoft.EntityFrameworkCore;
using orders.DAL.Models;

namespace orders.DAL.Repositories
{
    public class OrderRepository : Repository<Order>
    {
        public OrderRepository(DataContext context) : base(context)
        {
        }

        protected override DbSet<Order> GetData()
        {
            return _context.Orders;
        }
    }
}
