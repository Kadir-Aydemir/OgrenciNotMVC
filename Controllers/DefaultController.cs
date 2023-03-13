using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMVC.Models.EntityFramework;

namespace OgrenciNotMVC.Controllers
{
    public class DefaultController : Controller
    {
        DbOkulMvcEntities db = new DbOkulMvcEntities();

        public ActionResult Index()
        {
            var dersler = db.DERSLER.ToList();
            return View(dersler);
        }

        [HttpGet]
        public ActionResult YeniDers()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniDers(DERSLER d)
        {
            db.DERSLER.Add(d);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var ders = db.DERSLER.Find(id);
            db.DERSLER.Remove(ders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DersGetir(int id)
        {
            var ders = db.DERSLER.Find(id);
            return View("DersGetir", ders);
        }

        public ActionResult Guncelle(DERSLER d)
        {
            var ders=db.DERSLER.Find(d.DERSID);
            ders.DERSAD = d.DERSAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}