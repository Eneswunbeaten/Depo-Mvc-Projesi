using Microsoft.EntityFrameworkCore;
using MvcStok.Models.Entity;

namespace MvcStok.Data
{
    public class StokDbContext:DbContext
    {
        public StokDbContext(DbContextOptions<StokDbContext> options) : base(options) { }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Musteri> Musteriler { get; set; }
        public DbSet<Satis> Satislar { get; set; }
        public DbSet<Urun> Urunler { get; set; }
    }
}
