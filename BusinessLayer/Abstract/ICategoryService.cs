using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetList();
     
        void InsertCategory(Category p);

        Category GetByID(int id);

        void DeleteCategory(Category p);

        void UpdateCategory(Category p);
        
    }
}
