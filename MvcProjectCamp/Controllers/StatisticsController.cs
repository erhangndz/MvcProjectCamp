using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
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
        Context c= new Context();
        public ActionResult Index()
        {
            ViewBag.totalcategory = cm.TGetList().Count();
            ViewBag.Sinema= hm.TGetList().Where(x=>x.CategoryID==5).Count();
            ViewBag.WriternameA = wm.TGetList().Where(x => x.WriterName.ToLower().Contains("a")).Count();
            ViewBag.MaxHeaderCategory = c.Categories.OrderByDescending(c => c.Headers.Count).Select(c => c.CategoryName).FirstOrDefault();

            ViewBag.differencetruefalse = cm.TGetList().Where(x => x.CategoryStatus == true).Count() - cm.TGetList().Where(x => x.CategoryStatus == false).Count();
            return View();
        }
    }
}