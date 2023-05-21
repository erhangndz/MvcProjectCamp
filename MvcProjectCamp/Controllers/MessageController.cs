using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class MessageController : Controller
    {
        MessageManager mm=new MessageManager(new EfMessageDal());
        MessageValidator messagevalidator = new MessageValidator();
        [Authorize]
        public ActionResult Inbox()
        {
            var values= mm.TInboxList().OrderByDescending(x=>x.MessageID).ToList();
            return View(values);
        }

        public ActionResult Sentbox()
        {
            var values = mm.TSentList().OrderByDescending(x=>x.MessageID).ToList();
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
                p.Date= DateTime.Parse( DateTime.Now.ToShortDateString());
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

        public ActionResult GetInboxDetails(int id)
        {

            var values = mm.TGetByID(id);
            values.IsRead= true;
            mm.TUpdate(values);
            return View(values);
        }
        public ActionResult GetSentBoxDetails(int id)
        {

            var values = mm.TGetByID(id);
            return View(values);
        }
    }
}