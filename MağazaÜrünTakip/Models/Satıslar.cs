using System.ComponentModel.DataAnnotations;

namespace MağazaÜrünTakip.Models
{
    public class Satıslar
    {
        [Key]
        public int SatısId { get; set; }
        public decimal Fİyat { get; set; }
        public DateTime Tarih { get; set; }


        public Urunler Urunler { get; set; }
        public int UrunId { get; set; }

        public Personel Personel { get; set; }
        public int PersonelId { get; set; }


        public Musteri Musteri { get; set; }
        public int MusteriId { get; set; }

    }
}
