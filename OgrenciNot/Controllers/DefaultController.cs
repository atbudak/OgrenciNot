using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNot.Models.EntitiyFramework;
namespace OgrenciNot.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default

        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            var dersler = db.TBLDERSLER.ToList();
            return View(dersler);
        }
        [HttpGet]
        public ActionResult YeniDers()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniDers(TBLDERSLER p)
        {
            db.TBLDERSLER.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var ders = db.TBLDERSLER.Find(id);
            db.TBLDERSLER.Remove(ders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DersGetir(int id)
        {
            var dersGetir = db.TBLDERSLER.Find(id);
            return View("DersGetir",dersGetir);
        }
        public ActionResult Guncelle(TBLDERSLER d)
        {
            var drsG = db.TBLDERSLER.Find(d.DERSID);
            drsG.DERSAD = d.DERSAD;
            db.SaveChanges();
            return RedirectToAction("Index", "Default");
        }
    }
}