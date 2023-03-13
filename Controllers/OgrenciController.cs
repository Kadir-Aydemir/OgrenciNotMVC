using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMVC.Models.EntityFramework;

namespace OgrenciNotMVC.Controllers
{
    public class OgrenciController : Controller
    {
        DbOkulMvcEntities db = new DbOkulMvcEntities();
        public ActionResult Index()
        {
            var ogreciler = db.OGRENCILER.ToList();
            return View(ogreciler);
        }

        [HttpGet]
        public ActionResult YeniOgrenci()
        {
            List<SelectListItem> items = (from i in db.KULUPLER.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.KULUPAD,
                                              Value = i.KULUPID.ToString()
                                          }).ToList();
            ViewBag.klp = items;
            return View();
        }

        [HttpPost]
        public ActionResult YeniOgrenci(OGRENCILER o)
        {
            var klp = db.KULUPLER.Where(m => m.KULUPID == o.KULUPLER.KULUPID).FirstOrDefault();
            o.KULUPLER = klp;
            db.OGRENCILER.Add(o);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var ogr = db.OGRENCILER.Find(id);
            db.OGRENCILER.Remove(ogr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult OgrenciGetir(int id)
        {
            var ogr=db.OGRENCILER.Find(id);

            List<SelectListItem> items = (from i in db.KULUPLER.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.KULUPAD,
                                              Value = i.KULUPID.ToString()
                                          }).ToList();
            ViewBag.klp = items;

            return View("OgrenciGetir",ogr);
        }

        public ActionResult Guncelle(OGRENCILER o)
        {
           // var klp = db.KULUPLER.Where(m => m.KULUPID == o.KULUPLER.KULUPID).FirstOrDefault();
           // o.KULUPLER = klp;
            var ogr = db.OGRENCILER.Find(o.OGRID);
            ogr.OGRAD = o.OGRAD;
            ogr.OGRSOYAD = o.OGRSOYAD;
            ogr.OGRFOTO=o.OGRFOTO;
            ogr.OGRCINSIYET= o.OGRCINSIYET;
            ogr.OGRKULUP = o.KULUPLER.KULUPID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}