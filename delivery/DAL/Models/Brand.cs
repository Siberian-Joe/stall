namespace delivery.DAL.Models
{
    public class Brand : Model
    {
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }
    }
}
