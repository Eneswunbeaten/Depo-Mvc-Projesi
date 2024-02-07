using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcStok.Models.Entity
{
    public class Musteri
    {
        [Key]
        public int MusteriId { get; set; }
        [Required]
        public string MusteriAd { get; set; }
        [Required]
        public string MusteriSoyad { get; set; }
    }
}
