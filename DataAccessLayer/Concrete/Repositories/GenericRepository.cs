using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        Context c= new Context();
        DbSet<T> _t;

        public GenericRepository()
        {
            _t=c.Set<T>();
        }

        public void Delete(T t)
        {
            _t.Remove(t);
            c.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _t.SingleOrDefault(filter);
        }

        public List<T> GetList()
        {
           return _t.ToList();
        }

        public void Insert(T t)
        {
            _t.Add(t);
            c.SaveChanges();
        }

        public List<T> ListByExpression(Expression<Func<T, bool>> filter)
        {
            return _t.Where(filter).ToList();
        }

        public void Update(T t)
        {
            
            c.SaveChanges();
        }
    }
}
