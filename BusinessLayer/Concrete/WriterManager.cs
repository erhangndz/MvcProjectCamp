using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WriterManager : IWriterService
    {
        IWriterDal _writerdal;

        public WriterManager(IWriterDal writerdal)
        {
            _writerdal = writerdal;
        }

        public void TDelete(Writer t)
        {
            _writerdal.Delete(t);
        }

        public Writer TGetByID(int id)
        {
            return _writerdal.GetByID(id);
        }

        public List<Writer> TGetList()
        {
            return _writerdal.GetList();
        }

        public void TInsert(Writer t)
        {
           _writerdal.Insert(t);    
        }

        public void TUpdate(Writer t)
        {
            _writerdal.Update(t);
        }
    }
}
