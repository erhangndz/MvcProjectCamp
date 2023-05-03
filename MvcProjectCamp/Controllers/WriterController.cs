using BusinessLayer.Abstract;
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
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterDal());


        public ActionResult Index()
        {
            var values = wm.TGetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult UpdateWriter(int id)
        {
            var values = wm.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateWriter(Writer p)
        {
            WriterValidator writervalidator = new WriterValidator();
            ValidationResult results = writervalidator.Validate(p);
            if (results.IsValid)
            {
                wm.TUpdate(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            

            return View();
        }

        
        public ActionResult DeleteWriter(int id)
        {
            var values = wm.TGetByID(id);
            wm.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddWriter(Writer p)
        {
            WriterValidator writervalidator = new WriterValidator();
            ValidationResult results= writervalidator.Validate(p);
            if (results.IsValid)
            {
                wm.TInsert(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}