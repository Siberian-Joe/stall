namespace catalog.DAL.Models
{
    public abstract class Model : IModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
