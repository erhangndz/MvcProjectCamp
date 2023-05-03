using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class HeaderController : Controller
    {
       HeaderManager hm= new HeaderManager(new EfHeaderDal());


        public ActionResult Index()
        {
            var values = hm.TGetList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddHeader()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddHeader(Header p)
        {
            hm.TInsert(p);
            return RedirectToAction("Index");
        }
    }
}