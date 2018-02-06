using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WBlog.Controllers
{
    using Models;

    public class EtiketController : Controller
    {
        WBlogEntities db = new WBlogEntities();
        // GET: Etiket
        public ActionResult Index(int id)
        {
            return View(id);
        }

        public PartialViewResult EtiketWidget()
        {
            var data = db.Etiket.ToList();
            return PartialView(data);
        }

        public ActionResult MakaleListele(int id)
        {
            var data = db.Makale.Where(x=>x.Etiket.id==id/*x => x.Etiket1.Any(y => y.id == id*/).ToList() ;
            return View("MakaleListeleWidget",data);
        }
    }
}