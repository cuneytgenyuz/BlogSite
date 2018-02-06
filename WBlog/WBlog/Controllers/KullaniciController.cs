using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WBlog.Controllers
{
    using Models;
    using System.Web.Security;

    public class KullaniciController : Controller
    {
        WBlogEntities db = new WBlogEntities();
        // GET: Kullanici
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GirisYap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GirisYap(Kullanici kl)
        {
            string ka = ValidateUser(kl.kullaniciAdi, kl.parola);
            if (! string.IsNullOrEmpty(ka))
            {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, kl.kullaniciAdi, DateTime.Now, DateTime.Now.AddMinutes(15), true, ka, FormsAuthentication.FormsCookiePath);

                HttpCookie ck = new HttpCookie(FormsAuthentication.FormsCookieName);

                if (ticket.IsPersistent)
                {
                    ck.Expires = ticket.Expiration;
                }
                Response.Cookies.Add(ck);


                FormsAuthentication.RedirectFromLoginPage(kl.kullaniciAdi, true);
                
            }
            return RedirectToAction("GirisYap"/*"Index","Home"*/);
        }

        string ValidateUser(string ka, string pwd)
        {
            Kullanici kl = db.Kullanici.FirstOrDefault(x => x.kullaniciAdi == ka && x.parola == pwd);
            if (kl != null)
            {
                return kl.kullaniciAdi;
            }
            else
            {
                return "";                
            }
        }

        public ActionResult CikisYap(string redirectUrl)
        {
            FormsAuthentication.SignOut();
            return Redirect(redirectUrl);
        }

        public ActionResult UyeOl()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UyeOl(Kullanici kl,string rdBay, string rdBayan)
        {
            if (!string.IsNullOrEmpty(rdBay))
            {
                kl.cinsiyet = true;
            }
            if (!string.IsNullOrEmpty(rdBayan))
            {
                kl.cinsiyet = false;
            }
            kl.yazar = false;
            kl.onaylandi = true;
            kl.aktif = true;
            kl.dogumTarihi = kl.dogumTarihi.Value.Date;
            kl.kayitTarihi = DateTime.Now;
            db.Kullanici.Add(kl);
            db.SaveChanges();

            return RedirectToAction("GirisYap");
        }


       
    }
}