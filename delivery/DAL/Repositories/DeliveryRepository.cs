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

        public Delivery DeliverOrder (int id)
        {
            Delivery delivery = Get(id);

            if (delivery != null)
            {
                _context.Orders.Remove(delivery.Order);
                _context.Deliveries.Remove(delivery);
                _context.SaveChanges();
            }

            return delivery;
        }

        public override void Create(Delivery delivery)
        {
            delivery.Order = _context.Orders.FirstOrDefault(context => context.DeliveryId == null);

            base.Create(delivery);
        }

        public override Delivery Delete(int id)
        {
            Delivery delivery = Get(id);

            if (delivery != null)
            {
                Order order = _context.Orders.Find(delivery.Order.Id);
                order.DeliveryId = null;

                GetData().Remove(delivery);

                _context.SaveChanges();
            }

            return delivery;
        }

        protected override DbSet<Delivery> GetData()
        {
            return _context.Deliveries;
        }
    }
}
