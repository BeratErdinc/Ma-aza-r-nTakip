using System.ComponentModel.DataAnnotations;

namespace MağazaÜrünTakip.Models
{
    public class Personel
    {
        [Key]
        public int PersonelId { get; set; }
        public string PersonelAd { get; set; }
        public string PersonelSoyad { get; set; }
        public int PersonelDepartman { get; set; }

        public List<Satıslar> Satıslar { get; set; }
    }
}
