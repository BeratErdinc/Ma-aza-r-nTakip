using MağazaÜrünTakip.Models;
using Microsoft.AspNetCore.Mvc;
using PagedList;
using PagedList.Mvc;

namespace MağazaÜrünTakip.Controllers
{
    public class MusterıController : Controller
    {
        Context x = new Context();
        public IActionResult Index()
        {
            var liste = x.Musterıs.ToList();
            return View(liste);
        }
        [HttpGet]
        public IActionResult MusterıEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MusterıEkle(Musteri mst)
        {
            x.Musterıs.Add(mst);
            x.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult MusteriSil(int id)
        {
            var sil = x.Musterıs.Find(id);
            x.Musterıs.Remove(sil);
            x.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult MusterıDuzenle(int id)
        {
            var duzenle = x.Musterıs.Find(id);
            return View("MusterıDuzenle", duzenle);
        }
        public IActionResult MusterıGuncelle(Musteri mst)
        {
            var kata = x.Musterıs.Find(mst.MusteriId);
            kata.MusteriAd = mst.MusteriAd;
            kata.MusteriSoyad = mst.MusteriSoyad;
            kata.MusteriSehir = mst.MusteriSehir;
            kata.MusteriBakıye = mst.MusteriBakıye;
            x.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
