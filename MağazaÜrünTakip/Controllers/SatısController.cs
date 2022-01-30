using MağazaÜrünTakip.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MağazaÜrünTakip.Controllers
{
    public class SatısController : Controller
    {

        Context x = new Context();
        public IActionResult Index()
        {
            var liste = x.Satıslars.Include(x => x.Personel).Include(z=>z.Musteri).Include(o=>o.Urunler).ToList(); 
            return View(liste);
        }
        [HttpGet]
        public IActionResult SatısEkle()
        {
            List<SelectListItem> urun = (from i in x.Uruns.ToList()
                                         select new SelectListItem
                                         {
                                             Text = i.UrunAd,
                                             Value = i.UrunId.ToString()
                                         }

                                      ).ToList();

            ViewBag.dgr = urun;


            List<SelectListItem> satış = (from i in x.Uruns.ToList()
                                         select new SelectListItem
                                         {
                                             Text = i.SatısFıyat,
                                             Value = i.UrunId.ToString()
                                         }

                                      ).ToList();

            ViewBag.dgr4 = satış;



            List<SelectListItem> personel = (from i in x.Personels.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.PersonelAd + i.PersonelSoyad,
                                                 Value = i.PersonelId.ToString()
                                             }

                                     ).ToList();

            ViewBag.dgr2 = personel;

            List<SelectListItem> musteri = (from i in x.Musterıs.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.MusteriAd + i.MusteriSoyad,
                                                Value = i.MusteriId.ToString()
                                            }

                                     ).ToList();

            ViewBag.dgr3 = musteri;





            return View();
        }
        [HttpPost]
        public IActionResult SatısEkle(Satıslar st)
        {
            var urn = x.Uruns.Where(x => x.UrunId == st.Urunler.UrunId).FirstOrDefault();
            st.Urunler = urn;
            var perso = x.Personels.Where(z => z.PersonelId == st.Personel.PersonelId).FirstOrDefault();
            st.Personel = perso;
            var musterı = x.Musterıs.Where(k => k.MusteriId == st.Musteri.MusteriId).FirstOrDefault();
            st.Musteri = musterı;
            var satıs = x.Uruns.Where(k => k.UrunId.ToString() == st.Urunler.SatısFıyat).FirstOrDefault();
            st.Urunler = satıs;
            st.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            x.Satıslars.Add(st);
            x.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

