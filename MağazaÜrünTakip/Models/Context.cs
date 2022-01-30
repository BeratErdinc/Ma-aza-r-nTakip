using Microsoft.EntityFrameworkCore;

namespace MağazaÜrünTakip.Models
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-S9UV1QU\\BERAT; database=mağaza_urun_takıp; integrated security=true;");
        }
        public DbSet<Urunler>Uruns { get; set; }
        public DbSet<Kategori>Kategoris { get; set; }
        public DbSet<Personel>Personels { get; set; }
        public DbSet<Satıslar>Satıslars { get; set; }
        public DbSet<Musteri> Musterıs { get; set; }
    }
}
