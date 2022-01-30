using System.ComponentModel.DataAnnotations;

namespace MağazaÜrünTakip.Models
{
    public class Kategori
    {
        [Key]
        public int KategoriId{ get; set; }
        public string KategoriAd { get; set; }


        public List<Urunler> Urunler { get; set; }
    }
}
