namespace orders.DAL.Repositories
{
    public interface ICrudRepository<T>
    {
        IEnumerable<T> Get();
        T Get(int id);
        void Create(T item);
        void Update(T updatedItem);
        T Delete(int id);
    }
}
