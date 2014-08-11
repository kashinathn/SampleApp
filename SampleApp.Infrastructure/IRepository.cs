using System.Linq;

namespace SampleApp.Infrastructure
{
    public interface IRepository<TKey, T> where T : class, IEntityKey<TKey>
    {
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);

        IQueryable<T> All();
        T FindBy(TKey id);
    }
}
