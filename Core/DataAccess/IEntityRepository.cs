
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public  interface  IEntityRepository<T>
    {
        List<T> GetAll(Func<T, bool> filter = null);
        T Get(Func<T, bool> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
