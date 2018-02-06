using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WBlog.Controllers
{
    using App_Classes;
    using Models;
    using System.Drawing;

    public class MakaleController : Controller
    {
        WBlogEntities db = new WBlogEntities();
        // GET: Makale
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Detay(int id)
        {
            var data = db.Makale.FirstOrDefault(x => x.id == id);
            return View(data);
        }

        //[Authorize(Roles ="Admin")]
        //public ActionResult MakaleEkle()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[Authorize(Roles = "Admin")]
        //public ActionResult MakaleEkle(Makale m, string baslik,string icerik)
        //{
        //    m.eklenmeTarihi = DateTime.Now;
            


        //    m.baslik = baslik;
        //    m.icerik = icerik;
        //    db.Makale.Add(m);
        //    db.SaveChanges();

        //    return View();
        //}

        [AllowAnonymous]
        public string Begen(int id)
        {
            Makale makale = db.Makale.FirstOrDefault(x => x.id == id);
            makale.begeni++;
            db.SaveChanges();
            return makale.begeni.ToString();
        }

        [Authorize(Roles ="Admin,Yazar")]
        public ActionResult Ekle()
        {
            ViewBag.Kategoriler = db.Kategori.ToList();
            return View();
        }

        [HttpPost]
        [Authorize(Roles ="Admin,Yazar")]
        
        public ActionResult Ekle(Makale makale,HttpPostedFileBase resim)
        {
            Image img = Image.FromStream(resim.InputStream);
            Bitmap kckResim = new Bitmap(img,Settings.ResimKucukBoyut);
            Bitmap ortaResim = new Bitmap(img, Settings.ResimOrtakBoyut);
            Bitmap bykResim = new Bitmap(img, Settings.ResimBuyukBoyut);

            kckResim.Save(Server.MapPath("/Content/MakaleResim/KucukBoyut/" + resim.FileName));
            ortaResim.Save(Server.MapPath("/Content/MakaleResim/OrtaBoyut/" + resim.FileName));
            bykResim.Save(Server.MapPath("/Content/MakaleResim/BuyukBoyut/" + resim.FileName));

            Resim rsm = new Resim();
            rsm.buyukBoyut= "/Content/MakaleResim/BuyukBoyut/"+resim.FileName;
            rsm.ortaBoyut = "/Content/MakaleResim/OrtaBoyut/" + resim.FileName;
            rsm.kucukBoyut = "/Content/MakaleResim/KucukBoyut/" + resim.FileName;
            db.Resim.Add(rsm);
            db.SaveChanges();
            makale.resimID = rsm.id;
            makale.eklenmeTarihi = DateTime.Now;
            makale.goruntulenmeSayisi = 0;
            makale.begeni = 0;
            int yzrid = db.Kullanici.FirstOrDefault(x => x.kullaniciAdi == User.Identity.Name).id;
            makale.yazarID = yzrid;
            db.Makale.Add(makale);
            db.SaveChanges();
            return RedirectToAction("Index","Home");
        }
    }
}