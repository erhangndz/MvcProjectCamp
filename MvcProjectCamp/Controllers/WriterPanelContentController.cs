using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
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
        HeaderManager hm = new HeaderManager(new EfHeaderDal());
        public ActionResult MyContent(string p)
        {
            
            
            p = (string)Session["WriterMail"];
            var writeridinfo= wm.TGetList().Where(x=>x.WriterMail==p).Select(x=>x.WriterID).FirstOrDefault();
            var values = cm.TGetList().Where(x => x.WriterID == writeridinfo).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            var xid= hm.TGetByID(id);
            
            List<SelectListItem> header = (from x in hm.TGetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.HeaderName,
                                                 Value = x.HeaderID.ToString()
                                             }).ToList();
            ViewBag.header = xid.HeaderID;
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content p)
        {
            string mail = (string)Session["WriterMail"];
            var writeridinfo = wm.TGetList().Where(x => x.WriterMail == mail).Select(x => x.WriterID).FirstOrDefault();
            p.WriterID= writeridinfo;
            p.ContentDate = DateTime.Parse((DateTime.Now.ToShortDateString()));
            p.ContentStatus = true;
            cm.TInsert(p);
            return RedirectToAction("MyContent");
        }

        public ActionResult ToDoList()
        {
            return View();
        }
    }
}