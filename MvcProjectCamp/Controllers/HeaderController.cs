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


        public ActionResult Index(string p)
        {
            if (!string.IsNullOrEmpty(p))
            {
                var value = hm.GetHeaderbySearch(p);
                return View(value);
            }
            else
            {
                var values= hm.TGetList();
                return View(values);
            }
            
           
        }

        public ActionResult HeaderReport()
        {
            var values= hm.TGetList();
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

        [HttpGet]
        public ActionResult UpdateHeader(int id)
        {
            List<SelectListItem> category = (from x in cm.TGetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryID.ToString()
                                             }).ToList();
            ViewBag.category = category;
            var values= hm.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateHeader(Header p)
        {
            List<SelectListItem> category = (from x in cm.TGetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryID.ToString()
                                             }).ToList();
            ViewBag.category = category;
            var value = hm.TGetByID(p.HeaderID);
            value.HeaderName = p.HeaderName;
            value.CategoryID = p.CategoryID;
            hm.TUpdate(value);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteHeader(int id)
        {
            var values = hm.TGetByID(id);
            if (values.HeaderStatus == true)
            {
                values.HeaderStatus = false;
                hm.TUpdate(values);
            }
            else if(values.HeaderStatus == false)
            {
                values.HeaderStatus = true;
                hm.TUpdate(values);
            }
           
            
            return RedirectToAction("Index");
        }


    }
}