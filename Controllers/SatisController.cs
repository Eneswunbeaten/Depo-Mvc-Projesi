using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcStok.Data;
using MvcStok.Models.Entity;
using MvcStok.Models.ViewModels;
namespace MvcStok.Controllers
{
    public class SatisController : Controller
    {
        private readonly StokDbContext _context;
        public SatisController(StokDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int sayfa=0)
        {

            List<SatisViewModel> vm = (from s in _context.Satislar.ToList()
                                       join u in _context.Urunler.ToList()
                                       on s.Urun equals u.UrunId
                                       join m in _context.Musteriler.ToList()
                                       on s.Musteri equals m.MusteriId
                                       select new SatisViewModel
                                       {
                                           Id = s.SatisId,
                                           Urun = u.UrunAd,
                                           Musteri = m.MusteriAd + " " + m.MusteriSoyad,
                                           Adet = s.Adet,
                                           Fiyat = s.Fiyat
                                       }).ToList();
            return View(vm);
        }
        public IActionResult Ekle()
        {
            List<SelectListItem> musteriler = (from i in _context.Musteriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.MusteriAd + " " + i.MusteriSoyad,
                                                 Value = i.MusteriId.ToString()
                                             }).ToList();
            List<SelectListItem> urunler = (from i in _context.Urunler.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.UrunAd + " |" + i.Fiyat.ToString()+ "₺"+" | Stok:"+i.Stok.ToString(),
                                                Value = i.UrunId.ToString()
                                            }).ToList();
            ViewBag.urunler = urunler;
            ViewBag.musteriler = musteriler;
            return View();
        }
        [HttpPost]
        public IActionResult Ekle(Satis model)
        {
            if (ModelState.IsValid)
            {
                _context.Satislar.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View(model);
        }
        public IActionResult Kaldir(int id)
        {
            var satis = _context.Satislar.Find(id);
            if(satis is not null)
            {
                _context.Satislar.Remove(satis);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        public IActionResult Guncelle(int id)
        {
            var satis = _context.Satislar.Find(id);
            List<SelectListItem> urunler = (from i in _context.Urunler.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.UrunAd + " | " + i.Fiyat.ToString() + "₺" + " | Stok:" + i.Stok.ToString(),
                                                Value = i.UrunId.ToString()
                                            }).ToList();
            List<SelectListItem> musteriler = (from i in _context.Musteriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.MusteriAd+" "+i.MusteriSoyad,
                                                 Value = i.MusteriId.ToString()
                                             }).ToList();
            ViewBag.Surun = urunler;
            ViewBag.Smusteri = musteriler;
            return View("Guncelle", satis);
        }
        [HttpPost]
        public IActionResult Guncelle(int id, Satis model)
        {
            var satis = _context.Satislar.Find(id);
            if (ModelState.IsValid)
            {
                satis.Urun = model.Urun;
                satis.Musteri = model.Musteri;
                satis.Adet = model.Adet;
                satis.Fiyat = model.Fiyat;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
