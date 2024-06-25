using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Repository 
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        Context c=new Context();
        public void Delete(int id)
        {
            var value = c.Set<T>().Find(id);
            c.Set<T>().Remove(value);
            c.SaveChanges();
        }

        public T GetById(int id)
        {
            var value = c.Set<T>().Find(id);
            return value;
        }

        public List<T> GetListAll()
        {
            return c.Set<T>().ToList();
        }

        public void Insert(T entity)
        {
            c.Set<T>().Add(entity);
            c.SaveChanges();
        }

        public void Update(T entity)
        {
            c.Set<T>().Update(entity);
            c.SaveChanges();
        }
    }
}
