using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WBlog.Controllers
{
    using Models;

    public class KategoriController : Controller
    {
        WBlogEntities db = new WBlogEntities();

        // GET: Kategori
        public ActionResult Index(int id)
        {
            return View(id);
        }

        public PartialViewResult KategoriWidget()
        {
            return PartialView(db.Kategori.ToList());
        }

        public ActionResult MakaleListele(int id)
        {
            var data = db.Makale.Where(x => x.kategoriID == id).ToList();
            return View("MakaleListeleWidget",data);
        }
    }
}