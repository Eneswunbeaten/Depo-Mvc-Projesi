namespace MvcStok.Models.ViewModels
{
    public class UrunViewModel
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Kategori { get; set; }
        public decimal Fiyat { get; set; }
        public int Stok { get; set; }
    }
}
