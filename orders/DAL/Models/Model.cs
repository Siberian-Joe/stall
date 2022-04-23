namespace orders.DAL.Models
{
    public abstract class Model : IModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
