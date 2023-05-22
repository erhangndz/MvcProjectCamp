using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class HomeController : Controller
    {
        HeaderManager hm = new HeaderManager(new EfHeaderDal());
        ContentManager cm = new ContentManager(new EfContentDal());
        public ActionResult HomeLayout()
        {
            var values= hm.TGetList();
            return View(values);
        }


        public PartialViewResult Index()
        {
            var values= cm.TGetList();
            return PartialView(values);
        }
    }
}