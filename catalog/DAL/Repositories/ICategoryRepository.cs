using catalog.DAL.Models;

namespace catalog.DAL.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Get();
        Category Get(int id);
        void Create(Category item);
        void Update(Category updatedItem);
        Category Delete(int id);
    }
}
