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
    public class MessageManager : IMessageService
    {
         IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void TDelete(Message t)
        {
            _messageDal.Delete(t);
        }

        public Message TGetByID(int id)
        {
            return _messageDal.GetByID(id);
        }

        public List<Message> TGetList()
        {
            return _messageDal.GetList();
        }

        public List<Message> TInboxList()
        {
            return _messageDal.InboxList();
        }

        public void TInsert(Message t)
        {
            _messageDal.Insert(t);
        }

        public List<Message> TSentList()
        {
           return _messageDal.SentList();
        }

        public void TUpdate(Message t)
        {
           _messageDal.Update(t);
        }
    }
}
