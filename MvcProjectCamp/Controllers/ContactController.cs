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
        ContactValidator validator = new ContactValidator();
        public ActionResult Index()
        {
            ViewBag.messagenumber = cm.TGetList().Count();
            var values= cm.TGetList();  
            return View(values);
        }

        public ActionResult GetMessageDetails(int id)
        {
            ViewBag.messagenumber = cm.TGetList().Count();
            var values= cm.TGetByID(id);
        return View(values);
        }

        public PartialViewResult InboxPartial()
        {
            ViewBag.messagenumber = cm.TGetList().Count();
            return PartialView();
        }
    }
}