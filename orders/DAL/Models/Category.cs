namespace orders.DAL.Models
{
    public class Category : Model
    {
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }
    }
}
