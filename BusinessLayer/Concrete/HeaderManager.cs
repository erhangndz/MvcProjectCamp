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
    public class HeaderManager : IHeaderService
    {
        IHeaderDal _headerdal;

        public HeaderManager(IHeaderDal headerdal)
        {
            _headerdal = headerdal;
        }

        public List<Header> GetHeaderbySearch(string p)
        {
           return _headerdal.GetList().Where(x=>x.HeaderName.Contains(p)).ToList(); 
        }

        public void TDelete(Header t)
        {
            _headerdal.Delete(t);
        }

        public Header TGetByID(int id)
        {
            return _headerdal.GetByID(id);
        }

        public List<Header> TGetList()
        {
            return _headerdal.GetList();
        }

        public void TInsert(Header t)
        {
            _headerdal.Insert(t);
        }

        public void TUpdate(Header t)
        {
           _headerdal.Update(t);
        }
    }
}
