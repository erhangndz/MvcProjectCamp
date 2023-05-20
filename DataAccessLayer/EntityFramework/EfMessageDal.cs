using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfMessageDal : GenericRepository<Message>, IMessageDal
    {
        Context c= new Context();
        public List<Message> InboxList()
        {

            return c.Messages.Where(x=>x.Receiver=="admin@mail.com").ToList();
        }

        public List<Message> SentList()
        {
            return c.Messages.Where(x => x.Sender == "admin@mail.com").ToList();
        }
    }
}
