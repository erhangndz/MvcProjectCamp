using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;


namespace MvcProjectCamp.Controllers
{
    public class LoginController : Controller
    {
        AdminManager am = new AdminManager(new EfAdminDal()); 
        [HttpGet]
        public ActionResult Index()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            var values= am.TGetList().FirstOrDefault(x=>x.AdminUsername==p.AdminUsername && x.AdminPassword==p.AdminPassword);
            if (values!=null)
            {
                FormsAuthentication.SetAuthCookie(values.AdminUsername,false);
                Session["AdminUsername"] = values.AdminUsername;
                return RedirectToAction("Index", "AdminCategory");  
            }
            else
            {
                ViewBag.error = "Kullanıcı Adınız veya Şifreniz Hatalı, Tekrar Deneyin.";
                return RedirectToAction("Index");
                
            }
            
            return View();
        }

        

                

}
}