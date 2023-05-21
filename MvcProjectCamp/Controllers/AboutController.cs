using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class AboutController : Controller
    {
        AboutManager am = new AboutManager(new EfAboutDal());
        public ActionResult Index()
        {
            var values= am.TGetList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAbout(About p)
        {
            am.TInsert(p);
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }

        public ActionResult DeleteAbout(int id)
        {
            var values= am.TGetByID(id);
            if (values.AboutStatus == true)
            {
                values.AboutStatus = false;
                am.TUpdate(values);
              
            }
            else if(values.AboutStatus == false)
            {

                values.AboutStatus = true;
                am.TUpdate(values);
               
            }
            return RedirectToAction("Index");

        }

        
    }
}