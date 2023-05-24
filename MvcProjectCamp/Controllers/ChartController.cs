using MvcProjectCamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);

            List<CategoryModel> BlogList()
            {
                List<CategoryModel> cat = new List<CategoryModel>();
                cat.Add(new CategoryModel()
                {
                    CategoryName = "Yazılım",
                    CategoryNumber = 8
                });

                cat.Add(new CategoryModel()
                {
                    CategoryName = "Seyahat",
                    CategoryNumber = 4
                });
                cat.Add(new CategoryModel()
                {
                    CategoryName = "Teknoloji",
                    CategoryNumber = 7
                });

                cat.Add(new CategoryModel()
                {
                    CategoryName = "Spor",
                    CategoryNumber = 1
                });
                return cat;
            }


        }
    }
}