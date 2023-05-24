using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class ContactController : Controller
    {
       ContactManager cm= new ContactManager(new EfContactDal());
        MessageManager mm = new MessageManager(new EfMessageDal());
        ContactValidator validator = new ContactValidator();
        public ActionResult Index(string p)
        {
            if (!string.IsNullOrEmpty(p))
            {
                var value = cm.GetContactbySearch(p);
                return View(value);
            }
            else
            {
                var values = cm.TGetList();
                return View(values);
            }
           
        }

        public ActionResult GetMessageDetails(int id)
        {
           
            var values= cm.TGetByID(id);
            values.IsRead = true;
            cm.TUpdate(values);
        return View(values);
        }

        public PartialViewResult InboxPartial()
        {
            
            ViewBag.messagenumber = cm.TGetList().Count(x=>x.IsRead==false);
            ViewBag.inboxnumber = mm.TInboxList().Count(x=>x.IsRead==false);
            
            return PartialView();
        }
    }
}