using MağazaÜrünTakip.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MağazaÜrünTakip.Controllers
{
    public class UrunController : Controller
    {
        Context x = new Context();
        public IActionResult Index()
        {
            var urn = x.Uruns.Include(x=>x.Kategorı).ToList();
            return View(urn);
        }
         [HttpGet]
        public IActionResult UrunEkle()
        {
            List<SelectListItem> urun = (from i in x.Kategoris.ToList()
                                         select new SelectListItem
                                         {
                                             Text = i.KategoriAd,
                                             Value = i.KategoriId.ToString()
                                         }

                                      ).ToList();

            ViewBag.dgr = urun;
            return View();
        }
        [HttpPost]
        public IActionResult UrunEkle(Urunler urn)
        {
            var urun = x.Kategoris.Where(x => x.KategoriId == urn.Kategorı.KategoriId).FirstOrDefault();
            urn.Kategorı=urun;
            x.Uruns.Add(urn);
            x.SaveChanges();
            return RedirectToAction("Index");

          
        }
        public IActionResult UrunDuzenle(int id)
        {
            List<SelectListItem> urun = (from i in x.Kategoris.ToList()
                                         select new SelectListItem
                                         {
                                             Text = i.KategoriAd,
                                             Value = i.KategoriId.ToString()
                                         }

                                     ).ToList();

            ViewBag.dgr = urun;

            var per = x.Uruns.Where(x => x.UrunId == id).FirstOrDefault();

            return View("UrunDuzenle",per);
        }
        public IActionResult UrunGuncelle(Urunler urn)
        {
            var urun = x.Kategoris.Where(x => x.KategoriId == urn.Kategorı.KategoriId).FirstOrDefault();
            urn.Kategorı = urun;
            var per = x.Uruns.Where(x => x.UrunId == urn.UrunId).FirstOrDefault();
            per.UrunAd = urn.UrunAd;
            per.UrunMarka = urn.UrunMarka;
            per.UrunStok = urn.UrunStok;
            per.AlısFıyat = urn.AlısFıyat;
            per.SatısFıyat = urn.SatısFıyat;
            x.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult UrunSıl(Urunler urn)
        {
            var urunbul = x.Uruns.Find(urn.UrunId);
            urunbul.Durum = false;
            x.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
