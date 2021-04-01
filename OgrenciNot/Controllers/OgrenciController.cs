using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNot.Models.EntitiyFramework;
namespace OgrenciNot.Controllers
{
    public class OgrenciController : Controller
    {
        // GET: Ogrenci
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            var ogrenciler = db.TBLOGRENCILER.ToList();
            return View(ogrenciler);
        }
        [HttpGet]
        public ActionResult YeniOgrenci()
        {
            List<SelectListItem> degerler = (from i in db.TBLKULUPLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KULUPAD,
                                                 Value = i.KULUPID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult YeniOgrenci(TBLOGRENCILER o)
        {
            var kulup = db.TBLKULUPLER.Where(m => m.KULUPID == o.TBLKULUPLER.KULUPID).FirstOrDefault();
            o.TBLKULUPLER = kulup;
            db.TBLOGRENCILER.Add(o);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var ogr = db.TBLOGRENCILER.Find(id);
            db.TBLOGRENCILER.Remove(ogr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult OgrenciGetir(int id)
        {
            var ogrGetir = db.TBLOGRENCILER.Find(id);
            List<SelectListItem> degerler = (from i in db.TBLKULUPLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KULUPAD,
                                                 Value = i.KULUPID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("OgrenciGetir", ogrGetir);
        }
        public ActionResult Guncelle(TBLOGRENCILER o)
        {
            var ogrG = db.TBLOGRENCILER.Find(o.OGRENCIID);
            ogrG.OGRAD = o.OGRAD;
            ogrG.OGRSOYAD = o.OGRSOYAD;
            ogrG.OGRCINSIYET = o.OGRCINSIYET;
            ogrG.OGRFOTO = o.OGRFOTO;
            ogrG.OGRKULUP = o.TBLKULUPLER.KULUPID;
            db.SaveChanges();
            return RedirectToAction("Index", "Ogrenci");
        }
    }
}