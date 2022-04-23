namespace delivery.DAL.Models
{
    public class Order : Model
    {
        public string? Surname { get; set; }

        public virtual List<Product> Products { get; set; } = new List<Product>();

        public int? DeliveryId { get; set; }
        public virtual Delivery? Delivery { get; set; }
    }
}
