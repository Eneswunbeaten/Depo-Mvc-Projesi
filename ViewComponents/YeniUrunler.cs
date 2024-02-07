using Microsoft.AspNetCore.Mvc;
using MvcStok.Models.ViewModels;

namespace MvcStok.ViewComponents
{
    public class YeniUrunler:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var UrunListesi = new List<UrunViewModel>
            {
                new UrunViewModel
                {
                    Id = 1,
                    Ad="Usb Bellek",
                    Kategori="Bilgisayar Parçaları",
                    Stok=1500,
                    Fiyat=150
                },
                new UrunViewModel
                {
                    Id = 2,
                    Ad="Klavye",
                    Kategori="Bilgisayar Parçaları",
                    Stok=1500,
                    Fiyat=3500
                }
            };
            return View(UrunListesi);
        }
    }
}
