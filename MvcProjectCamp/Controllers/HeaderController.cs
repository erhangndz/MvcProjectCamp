using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

namespace MvcProjectCamp.Controllers
{
    public class HeaderController : Controller
    {
        HeaderManager hm = new HeaderManager(new EfHeaderDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());


        public ActionResult Index()
        {
            var values = hm.TGetList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddHeader()
        {
            List<SelectListItem> category = (from x in cm.TGetList()
                                         select new SelectListItem
                                         {
                                             Text = x.CategoryName,
                                             Value = x.CategoryID.ToString()
                                         }).ToList();
            List<SelectListItem> writer = (from x in wm.TGetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.WriterName+ " " + x.WriterSurname,
                                                 Value = x.WriterID.ToString()
                                             }).ToList();
            ViewBag.category = category;
            ViewBag.writer = writer;
                               
            return View();
        }


        [HttpPost]
        public ActionResult AddHeader(Header p)
        {
            p.HeaderDate = DateTime.Parse((DateTime.Now.ToShortDateString()));
            hm.TInsert(p);
            return RedirectToAction("Index");
        }
    }
}