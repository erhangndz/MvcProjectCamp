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
    public class WriterPanelMessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messagevalidator = new MessageValidator();

        public ActionResult Inbox()
        {
            var values = mm.TGetList().OrderByDescending(x => x.MessageID).Where(x=>x.Receiver=="ercan@mail.com").ToList();
            return View(values);
        }

        public PartialViewResult WriterMessageMenu()
        {
            
            ViewBag.inboxnumber = mm.TGetList().Where(x=>x.Receiver=="ercan@mail.com").Count(x => x.IsRead == false);

            return PartialView();
        }

        public ActionResult Sentbox()
        {
            var values = mm.TGetList().OrderByDescending(x => x.MessageID).Where(x=>x.Sender=="ercan@mail.com").ToList();
            return View(values);
        }
    }
}