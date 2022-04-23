namespace delivery.DAL.Models
{
    public class Delivery : Model
    {
        public string? Surname { get; set; }

        public virtual Order? Order { get; set; }
    }
}
