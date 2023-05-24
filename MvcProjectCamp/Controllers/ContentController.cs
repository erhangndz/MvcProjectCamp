using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{

    public class ContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());

        public ActionResult Index()
        {
            var values = cm.TGetList();
            return View(values);
        }

        public ActionResult GetAllContent(string p)
        {
            if (!string.IsNullOrEmpty(p))
            {
                var value = cm.GetListbySearch(p);
                return View(value);
            }
            else
            {
                var values = cm.TGetList();
                return View(values);
            }
           
        }

        public ActionResult GetContent(int id)
        {
            var values = cm.TGetList().Where(x => x.HeaderID == id).ToList();
            return View(values);
        }
    }
}