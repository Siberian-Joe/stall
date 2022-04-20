namespace catalog.DAL.Models
{
    public class Product : Model
    {
        public string Description { get; set; }

        public virtual Category Category { get; set; }
        public virtual Brand Brand { get; set; }
    }
}
