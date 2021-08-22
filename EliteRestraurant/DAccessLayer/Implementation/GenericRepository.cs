using DAccessLayer.Abstract;
using EliteRestraurantEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAccessLayer.Implementation
{
    public class GenericRepository<T, K> : IGenericRepository<T, K> where T : BaseEntity<K>
    {
        public readonly EliteRestraurantContext context;

        public GenericRepository(EliteRestraurantContext context)
        {
            this.context = context;
        }

        ///hui
        public virtual void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public void Delete(K id)
        {
            context.Set<T>().Remove(this.Get(id));
        }

        public T Get(K id)
        {
            return context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            T find = this.Get(entity.Id);
            context.Entry(find).CurrentValues.SetValues(entity);
        }

        public List<T> GetAll()
        {
            return context.Set<T>().ToList();
        }
    }
}
