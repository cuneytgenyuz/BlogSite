using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WBlog.Controllers
{
    using Models;
    public class AdminController : Controller
    {
        WBlogEntities db = new WBlogEntities();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult YazarOnaylari()
        {
            var data = db.Kullanici.Where(x => x.yazar == true && x.onaylandi == false).ToList();
            return View(data);
        }

        public ActionResult OnayVer(int id)
        {
            Kullanici kl = db.Kullanici.FirstOrDefault(x => x.id == id);
            kl.onaylandi = true;

            db.SaveChanges();

            return RedirectToAction("YazarOnaylari");
        }
    }
}