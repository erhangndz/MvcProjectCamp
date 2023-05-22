﻿    using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class WriterPanelController : Controller
    {
        HeaderManager hm = new HeaderManager(new EfHeaderDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult WriterProfile()
        {
            return View();
        }

        public ActionResult MyHeaders(string p) 
        {

            p = (string)Session["WriterMail"];
            var writeridinfo = wm.TGetList().Where(x => x.WriterMail == p).Select(x => x.WriterID).FirstOrDefault();
            var values = hm.TGetList().Where(x => x.WriterID == writeridinfo).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult NewHeader()
        {
            List<SelectListItem> category = (from x in cm.TGetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryID.ToString()
                                             }).ToList();
            ViewBag.category=category;
            return View();
        }
        [HttpPost]
        public ActionResult NewHeader(Header p)
        {
            string y = (string)Session["WriterMail"];
            var writeridinfo = wm.TGetList().Where(x => x.WriterMail == y).Select(x => x.WriterID).FirstOrDefault();
            p.HeaderDate = DateTime.Parse((DateTime.Now.ToShortDateString()));
            p.WriterID = writeridinfo;
            p.HeaderStatus = true;
            hm.TInsert(p);
            return RedirectToAction("MyHeaders");
          
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
            var values = hm.TGetByID(id);
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
            return RedirectToAction("MyHeaders");
        }

        public ActionResult DeleteHeader(int id)
        {
            var values = hm.TGetByID(id);
            if (values.HeaderStatus == true)
            {
                values.HeaderStatus = false;
                hm.TUpdate(values);
            }
            else if (values.HeaderStatus == false)
            {
                values.HeaderStatus = true;
                hm.TUpdate(values);
            }


            return RedirectToAction("MyHeaders");
        }
    }
}