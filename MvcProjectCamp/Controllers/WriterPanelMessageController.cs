using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
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
        WriterManager wm = new WriterManager(new EfWriterDal());
        MessageValidator messagevalidator = new MessageValidator();

        public ActionResult Inbox()
        {
            string p = (string)Session["WriterMail"];
            var writermailinfo = wm.TGetList().Where(x => x.WriterMail == p).Select(x => x.WriterMail).FirstOrDefault();
            var values = mm.TGetList().OrderByDescending(x => x.MessageID).Where(x=>x.Receiver==writermailinfo).ToList();
            return View(values);
        }

        public PartialViewResult WriterMessageMenu()
        {
            string p = (string)Session["WriterMail"];
            var writermailinfo = wm.TGetList().Where(x => x.WriterMail == p).Select(x => x.WriterMail).FirstOrDefault();
            ViewBag.inboxnumber = mm.TGetList().Where(x=>x.Receiver==writermailinfo).Count(x => x.IsRead == false);

            return PartialView();
        }

        public ActionResult Sentbox()
        {
            string p = (string)Session["WriterMail"];
            var writermailinfo = wm.TGetList().Where(x => x.WriterMail == p).Select(x => x.WriterMail).FirstOrDefault();
            var values = mm.TGetList().OrderByDescending(x => x.MessageID).Where(x=>x.Sender==writermailinfo).ToList();
            return View(values);
        }

        public ActionResult GetInboxDetails(int id)
        {

            var values = mm.TGetByID(id);
            values.IsRead = true;
            mm.TUpdate(values);
            return View(values);
        }
        public ActionResult GetSentBoxDetails(int id)
        {

            var values = mm.TGetByID(id);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {

            ValidationResult results = messagevalidator.Validate(p);
            if (results.IsValid)
            {

                p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());

                p.Sender = (string)Session["WriterMail"];
                mm.TInsert(p);
                return RedirectToAction("Sentbox");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }



        }
    }
}