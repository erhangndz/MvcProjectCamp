﻿using BusinessLayer.Concrete;
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
        public ActionResult Index()
        {
            var values = cm.GetList();
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
                cm.InsertCategory(p);
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
            var values=cm.GetByID(id);
            cm.DeleteCategory(values);
          
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var values=cm.GetByID(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateCategory(Category p)
        {
           
            cm.UpdateCategory(p);
            
            return RedirectToAction("Index");
        }

        

    }
}