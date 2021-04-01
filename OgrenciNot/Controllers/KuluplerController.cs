using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNot.Models.EntitiyFramework;

namespace OgrenciNot.Controllers
{
    public class KuluplerController : Controller
    {
        // GET: Kulupler
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            var kulupler = db.TBLKULUPLER.ToList();
            return View(kulupler);
        }
        [HttpGet]
        public ActionResult YeniKulup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKulup(TBLKULUPLER k)
        {
            db.TBLKULUPLER.Add(k);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var kulup = db.TBLKULUPLER.Find(id);
            db.TBLKULUPLER.Remove(kulup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KulupGetir(int id)
        {
            var kulupGetir = db.TBLKULUPLER.Find(id);
            return View("KulupGetir",kulupGetir);
        }
        public ActionResult Guncelle(TBLKULUPLER k)
        {
            var klpG = db.TBLKULUPLER.Find(k.KULUPID);
            klpG.KULUPAD = k.KULUPAD;
            db.SaveChanges();
            return RedirectToAction("Index", "Kulupler");
        }
    }
}