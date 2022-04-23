using Microsoft.EntityFrameworkCore;
using delivery.DAL.Models;

namespace delivery.DAL.Repositories
{
    public class DeliveryRepository : Repository<Delivery>
    {
        public DeliveryRepository(DataContext context) : base(context)
        {
        }

        public void RegistrationOrderInDelivery(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public override void Create(Delivery delivery)
        {
            delivery.Order = _context.Orders.FirstOrDefault();

            base.Create(delivery);
        }

        protected override DbSet<Delivery> GetData()
        {
            return _context.Deliveries;
        }
    }
}
