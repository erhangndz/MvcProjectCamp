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
    
    public class ContentManager : IContentService
    {
         IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public List<Content> GetListbySearch(string p)
        {
           return _contentDal.GetList().Where(x=>x.ContentText.Contains(p)).ToList();
        }

        public void TDelete(Content t)
        {
            _contentDal.Delete(t);
        }

        public Content TGetByID(int id)
        {
            return _contentDal.GetByID(id);
        }

        public List<Content> TGetList()
        {
            return _contentDal.GetList();
        }

        public void TInsert(Content t)
        {
            _contentDal.Insert(t);
        }

        public void TUpdate(Content t)
        {
            _contentDal.Update(t);
        }
    }
}
