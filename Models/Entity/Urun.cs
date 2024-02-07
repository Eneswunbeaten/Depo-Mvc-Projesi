using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcStok.Models.Entity
{
    public class Urun
    {
        [Key]
        public int UrunId { get; set; }
        public string UrunAd { get; set; }
        public int UrunKategori { get; set; }
        public decimal Fiyat { get; set; }
        public int Stok { get; set; }
    }
}
