using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMVC.Models.EntityFramework;
using OgrenciNotMVC.Models;


namespace OgrenciNotMVC.Controllers
{
    public class NotController : Controller
    {
        DbOkulMvcEntities db=new DbOkulMvcEntities();
        public ActionResult Index()
        {
            var not = db.NOTLAR.ToList();
            return View(not);
        }

        [HttpGet]
        public ActionResult YeniSinav()
        {
            List<SelectListItem> items = (from i in db.DERSLER.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.DERSAD,
                                              Value = i.DERSID.ToString()
                                          }).ToList();
            ViewBag.drs = items;
            return View();
        }

        [HttpPost]
        public ActionResult YeniSinav(NOTLAR n)
        {
            var drs = db.DERSLER.Where(m => m.DERSID == n.DERSLER.DERSID).FirstOrDefault();
            n.DERSLER = drs;
            db.NOTLAR.Add(n);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult NotGetir(int id)
        {
            var not = db.NOTLAR.Find(id);
            return View("NotGetir",not);
        }

        [HttpPost]
        public ActionResult NotGetir(NOTLAR n,Class1 model, int sinav1=0,int sinav2=0,int sinav3=0,int proje=0)
        {
            if (model.islem == "HESAPLA")
            {
                int ortalama = (sinav1 + sinav2 + sinav3 + proje) / 4;
                ViewBag.ort = ortalama;
            }
            if (model.islem == "GUNCELLE")
            {
                var snv = db.NOTLAR.Find(n.NOTID);
                snv.SINAV1 = n.SINAV1;
                snv.SINAV2= n.SINAV2;
                snv.SINAV3= n.SINAV3;
                snv.PROJE = n.PROJE;
                snv.ORTALAMA = n.ORTALAMA;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}