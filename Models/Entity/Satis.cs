using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcStok.Models.Entity
{ 
    public class Satis
    {
        [Key]
        public int SatisId { get; set; }
        public int Urun { get; set; }
        public int Musteri { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
    }
}
