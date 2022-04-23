using delivery.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace delivery.DAL.Repositories
{
    public abstract class Repository<T> : ICrudRepository<T> where T : Model
    {
        protected DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }

        public virtual IEnumerable<T> Get()
        {
            return GetData();
        }

        public virtual T Get(int id)
        {
            return GetData().Find(id);
        }

        public virtual void Create(T item)
        {
            GetData().Add(item);
            _context.SaveChanges();
        }

        public virtual void Update(T updatedItem)
        {
            T currentItem = Get(updatedItem.Id);
            currentItem.Name = updatedItem.Name;

            GetData().Update(currentItem);
            _context.SaveChanges();
        }

        public virtual T Delete(int id)
        {
            T item = Get(id);

            if (item != null)
            {
                GetData().Remove(item);
                _context.SaveChanges();
            }

            return item;
        }

        protected abstract DbSet<T> GetData();
    }
}
