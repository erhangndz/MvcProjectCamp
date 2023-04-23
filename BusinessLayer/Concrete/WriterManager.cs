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

        public void DeleteWriter(Writer p)
        {
            _writerdal.Delete(p);
        }

        public Writer GetByID(int id)
        {
            return _writerdal.Get(x=>x.WriterID==id);
        }

        public List<Writer> GetList()
        {
            throw new NotImplementedException();
        }

        public void InsertWriter(Writer p)
        {
            throw new NotImplementedException();
        }

        public void UpdateWriter(Writer P)
        {
            throw new NotImplementedException();
        }
    }
}
