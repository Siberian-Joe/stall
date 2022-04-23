namespace orders.DAL.Models
{
    public class Product : Model
    {
        public string? Description { get; set; }

        public virtual Category? Category { get; set; }
        public virtual Brand? Brand { get; set; }

        public int OrderId { get; set; }
        public virtual Order? Order { get; set; }
    }
}
