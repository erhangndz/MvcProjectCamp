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
using reCaptcha.Extensions;


namespace MvcProjectCamp.Controllers
{
    public class LoginController : Controller
    {
        AdminManager am = new AdminManager(new EfAdminDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            var values = am.TGetList().FirstOrDefault(x => x.AdminUsername == p.AdminUsername && x.AdminPassword == p.AdminPassword);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.AdminUsername, false);
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

        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer p)
        {
            var values = wm.TGetList().FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);
            if (values != null )
            {
                FormsAuthentication.SetAuthCookie(values.WriterMail, false);
                Session["WriterMail"] = values.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "reCAPTCHA doğrulaması başarısız.");
                return RedirectToAction("WriterLogin");

            }

            return View();
        }


    }
}