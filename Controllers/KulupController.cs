using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMVC.Models.EntityFramework;

namespace OgrenciNotMVC.Controllers
{
    public class KulupController : Controller
    {
        DbOkulMvcEntities db=new DbOkulMvcEntities();
        public ActionResult Index()
        {
            var kulupler = db.KULUPLER.ToList();
            return View(kulupler);
        }

        [HttpGet]
        public ActionResult YeniKulup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKulup(KULUPLER k)
        {
            db.KULUPLER.Add(k);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var kulup = db.KULUPLER.Find(id);
            db.KULUPLER.Remove(kulup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KulupGetir(int id)
        {
            var kulup = db.KULUPLER.Find(id);
            return View("KulupGetir", kulup);
        }

        public ActionResult Guncelle(KULUPLER k)
        {
            var klp=db.KULUPLER.Find(k.KULUPID);
            klp.KULUPAD = k.KULUPAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}