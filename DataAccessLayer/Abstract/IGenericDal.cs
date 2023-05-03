using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        List<T> GetList();

        T Get(Expression<Func<T, bool>> filter);

        void Insert(T t);
        void Update(T t);
        void Delete(T t);
       T GetByID(int id);

        List<T> ListByExpression(Expression<Func<T, bool>> filter);
    }
}
