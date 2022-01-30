using MağazaÜrünTakip.Models;
using Microsoft.AspNetCore.Mvc;

namespace MağazaÜrünTakip.Controllers
{
    public class KategoriController : Controller
    {
        Context x = new Context();
        public IActionResult Index()
        {
            var liste = x.Kategoris.ToList();
            return View(liste);
        }
        [HttpGet]
        public IActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult KategoriEkle(Kategori kg)
        {
            x.Kategoris.Add(kg);
            x.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult KategoriSil(int id)
        {
            var sil = x.Kategoris.Find(id);
            x.Kategoris.Remove(sil);
            x.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult KategoriGetir(int id)
        {
            var getir = x.Kategoris.Find(id);
            return View("KategoriGetir",getir);
        }
        public IActionResult Güncelle(Kategori kg)
        {
            var kata = x.Kategoris.Find(kg.KategoriId);
            kata.KategoriAd = kg.KategoriAd;
            x.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
