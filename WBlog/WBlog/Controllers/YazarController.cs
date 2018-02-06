using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WBlog.Controllers
{
    using Models;
    public class YazarController : Controller
    {
        WBlogEntities db = new WBlogEntities();
        // GET: Yazar
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Üye")]
        public ActionResult YazarOl()
        {
            return View();
        }

        
        [HttpPost]
        [Authorize(Roles = "Üye")]
        public ActionResult YazarOl(Kullanici kl, string rdBay, string rdBayan)
        {
            if (!string.IsNullOrEmpty(rdBay))
            {
                kl.cinsiyet = true;
            }
            if (!string.IsNullOrEmpty(rdBayan))
            {
                kl.cinsiyet = false;
            }

            kl.yazar = true;
            kl.onaylandi = false;
            kl.aktif = true;
            kl.kayitTarihi = DateTime.Now;

            db.Kullanici.Add(kl);
            db.SaveChanges();

            Rol yazar = db.Rol.FirstOrDefault(x => x.adi == "Yazar");

            KullaniciRol kr = new KullaniciRol();
            kr.rolID = yazar.id;
            kr.kullaniciID = kl.id;

            db.KullaniciRol.Add(kr);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}