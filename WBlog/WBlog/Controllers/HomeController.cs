using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WBlog.Controllers
{
    using Models;
    using App_Classes;
    public class HomeController : Controller
    {
        // GET: Home

        WBlogEntities db = new WBlogEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MakaleListele()
        {
            var data = db.Makale.ToList();
            return View("MakaleListeleWidget",data);
        }

        public PartialViewResult PopulerMakalelerWidget()
        {
            var model= db.Makale.OrderByDescending(x=>x.eklenmeTarihi).Take(3).ToList();

            return PartialView(model);
        }

        
    }
}