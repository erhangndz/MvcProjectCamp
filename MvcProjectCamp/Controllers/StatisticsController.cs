using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class StatisticsController : Controller
    {

        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        HeaderManager hm = new HeaderManager(new EfHeaderDal());
        public ActionResult Index()
        {
            ViewBag.totalcategory = cm.TGetList().Count();
            ViewBag.Sinema= hm.TGetList().Where(x=>x.CategoryID==5).Count();
            ViewBag.WriternameA = wm.TGetList().Where(x => x.WriterName.ToLower().Contains("a")).Count();
            ViewBag.MaxHeaderCategory = cm.TGetList().Where(x => x.CategoryID == 5).First();
            ViewBag.differencetruefalse = cm.TGetList().Where(x => x.CategoryStatus == true).Count() - cm.TGetList().Where(x => x.CategoryStatus == false).Count();
            return View();
        }
    }
}