using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using SampleApp.Infrastructure;

namespace SampleApp.Repository
{
    public class Repository<TKey, T> : IRepository<TKey, T> where T : class, IEntityKey<TKey>
    {
        private readonly ISession _session;
        public Repository(ISession session)
        {
            _session = session;
        }

        public bool Add(T entity)
        {
            _session.Save(entity);
            return true;
        }

        public bool Add(IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                _session.Save(item);
            }
            return true;
        }

        public bool Update(T entity)
        {
            _session.Update(entity);
            return true;
        }

        public bool Delete(T entity)
        {
            _session.Delete(entity);
            return true;
        }

        public IQueryable<T> All()
        {
            return _session.Query<T>();
        }

        public T FindBy(TKey id)
        {
            return _session.Get<T>(id);
        }
    }
}
