using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult MyContent(string p)
        {
            
            
            p = (string)Session["WriterMail"];
            var writeridinfo= wm.TGetList().Where(x=>x.WriterMail==p).Select(x=>x.WriterID).FirstOrDefault();
            var values = cm.TGetList().Where(x => x.WriterID == writeridinfo).ToList();
            return View(values);
        }
    }
}