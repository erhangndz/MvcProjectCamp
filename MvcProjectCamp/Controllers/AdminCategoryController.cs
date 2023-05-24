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
 
    public class AdminCategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        [Authorize(Roles ="b")]
        public ActionResult Index()
        {
            var values = cm.TGetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category p)
        {

            CategoryValidator validator = new CategoryValidator();
            ValidationResult result = validator.Validate(p);
            if (result.IsValid)
            {
                cm.TInsert(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
                return View();
            }

        }

        public ActionResult DeleteCategory(int id)
        {
            var values=cm.TGetByID(id);
            if (values.CategoryStatus == true)
            {
                values.CategoryStatus = false;
            }
            else if (values.CategoryStatus == false)
            {
                values.CategoryStatus = true;
            }
            
            cm.TUpdate(values);
          
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var values=cm.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateCategory(Category p)
        {
           p.CategoryStatus = true;
            cm.TUpdate(p);
            
            return RedirectToAction("Index");
        }

        

    }
}