using MağazaÜrünTakip.Models;
using Microsoft.AspNetCore.Mvc;

namespace MağazaÜrünTakip.Controllers
{
    public class PersonelController : Controller
    {
        Context context = new Context();
        public IActionResult Index()
        {
            var liste = context.Personels.ToList();
            return View(    liste);
        }
        [HttpGet]
        public IActionResult PersonelEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult PersonelEkle(Personel bp)
        {
            context.Personels.Add(bp);
            context.SaveChanges();  
            return RedirectToAction("Index");   
        }
        
    }
}
