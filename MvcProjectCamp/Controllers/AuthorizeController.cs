using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;



namespace MvcProjectCamp.Controllers
{
    public class AuthorizeController : Controller
    {
        AdminManager am = new AdminManager(new EfAdminDal());
        public ActionResult Index()
        {
            var values= am.TGetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddAdmin() 
        {
        return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {
            am.TInsert(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAdmin(int id)
        {
            var values = am.TGetByID(id);
            if (values.AdminStatus == true)
            {
                values.AdminStatus = false;
            }
            else if (values.AdminStatus == false)
            {
                values.AdminStatus = true;
            }

            am.TUpdate(values);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {
            List<SelectListItem> role = (from x in am.TGetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.AdminRole,
                                                 Value = x.AdminRole
                                             }).ToList();
            ViewBag.role = role;
            var values = am.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateAdmin(Admin p)
        {
            p.AdminStatus = true;
            am.TUpdate(p);

            return RedirectToAction("Index");
        }
    }
}