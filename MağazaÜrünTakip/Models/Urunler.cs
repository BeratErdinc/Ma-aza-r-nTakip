using System.ComponentModel.DataAnnotations;

namespace MağazaÜrünTakip.Models
{
    public class Urunler
    {
        [Key]
        public int UrunId { get; set; }
        public string UrunAd { get; set; }
        public string UrunMarka { get; set; }
        public string UrunStok { get; set; }
        public string AlısFıyat { get; set; }
        public string SatısFıyat { get; set; }

        public bool Durum { get; set; }

        public List<Satıslar> Satıslar { get; set; }
        public Kategori Kategorı { get; set; }
        public int KategorıId { get; set; }
    }
}
