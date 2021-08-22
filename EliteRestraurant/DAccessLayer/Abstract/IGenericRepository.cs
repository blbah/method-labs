using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAccessLayer.Abstract
{
    public interface IGenericRepository<T, K>
    {
        void Add(T entity);
        void Update(T entity);
        T Get(K id);
        void Delete(K id);
        List<T> GetAll();
    }
}
