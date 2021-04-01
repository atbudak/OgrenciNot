using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OgrenciNot.Controllers
{
    public class HesapTestController : Controller
    {
        // GET: HesapTest
        public ActionResult Index(int sayi1 = 0 ,int sayi2 = 0)
        {
            var sonuc = sayi1 + sayi2;
            var sonuc1 = sayi1 - sayi2;
            var sonuc2 = sayi1 * sayi2;
            double sonuc3 = (double)sayi1 / (double)sayi2;
            ViewBag.snc = sonuc;
            ViewBag.snc1 = sonuc1;
            ViewBag.snc2 = sonuc2;
            ViewBag.snc3 = sonuc3;
            return View();
        }
    }
}