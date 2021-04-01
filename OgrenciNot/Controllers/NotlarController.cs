using OgrenciNot.Models;
using OgrenciNot.Models.EntitiyFramework;
using System.Linq;
using System.Web.Mvc;

namespace OgrenciNot.Controllers
{
    public class NotlarController : Controller
    {
        // GET: Notlar
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            var notlar = db.TBLNOTLAR.ToList();
            return View(notlar);
        }
        [HttpGet]
        public ActionResult YeniSinav()
        {          
            return View();
        }
        [HttpPost]
        public ActionResult YeniSinav(TBLNOTLAR nt)
        {
            db.TBLNOTLAR.Add(nt);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SinavGetir(int id)
        {
            var snvGetir = db.TBLNOTLAR.Find(id);
            return View("SinavGetir", snvGetir);
        }
        [HttpPost]
        public ActionResult SinavGetir(NotClass cls,TBLNOTLAR n, int id,int SINAV1 = 0, int SINAV2 = 0, int SINAV3 = 0, int PROJE = 0)
        {
            
            if (cls.islem == "HESAPLA"){

                int ORTALAMA = (SINAV1 + SINAV2 + SINAV3 + PROJE) / 4;
                ViewBag.ort = ORTALAMA;
              
            }
            if (cls.islem == "NOTGUNCELLE")
            {
                ViewBag.durum = "";
                var ntG = db.TBLNOTLAR.Find(id);
                ntG.SINAV1 = n.SINAV1;
                ntG.SINAV2 = n.SINAV2;
                ntG.SINAV3 = n.SINAV3;
                ntG.PROJE = n.PROJE;
                ntG.ORTALAMA = n.ORTALAMA;
                if(ntG.ORTALAMA >= 50 && ntG.ORTALAMA <=100)
                {
                    n.DURUM = true;
                    ntG.DURUM = n.DURUM;
                }
                else if(ntG.ORTALAMA <= 50 && ntG.ORTALAMA >= 0)
                {
                    n.DURUM = false;
                    ntG.DURUM = n.DURUM;
                }               
                db.SaveChanges();
                return RedirectToAction("Index", "Notlar");
            }
            
            return View();
        }
    }
}