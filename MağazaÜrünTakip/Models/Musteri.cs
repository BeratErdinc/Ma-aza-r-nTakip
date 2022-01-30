using System.ComponentModel.DataAnnotations;

namespace MağazaÜrünTakip.Models
{
    public class Musteri
    {
        [Key]
        public int MusteriId { get; set; }
        public string MusteriAd { get; set; }
        public string MusteriSoyad { get; set; }
        public string MusteriSehir { get; set; }
        public string MusteriBakıye { get; set; }

        public List<Satıslar> Satıslar { get; set; }
    }
}
