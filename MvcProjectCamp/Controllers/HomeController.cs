using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        HeaderManager hm = new HeaderManager(new EfHeaderDal());
        ContentManager cm = new ContentManager(new EfContentDal());
        public ActionResult HomeLayout()
        {
            var values= hm.TGetList();
            return View(values);
        }


        public PartialViewResult Index(int id=0)
        {
            var values = cm.TGetList().Where(x => x.HeaderID == id).ToList();
            return PartialView(values);
        }

        public ActionResult HomePage()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult NavbarPartial()
        {
            return PartialView();
        }
        

       
    }
}