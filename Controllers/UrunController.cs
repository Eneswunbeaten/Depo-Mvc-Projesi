using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcStok.Data;
using MvcStok.Models.Entity;
using MvcStok.Models.ViewModels;

namespace MvcStok.Controllers
{
    public class UrunController : Controller
    {
        private readonly StokDbContext _context;
        public UrunController(StokDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<UrunViewModel> vm = (from u in _context.Urunler.ToList()
                                      join k in _context.Kategoriler.ToList()
                                      on u.UrunKategori equals k.KategoriId
                                      select new UrunViewModel
                                      {
                                          Id = u.UrunId,
                                          Ad = u.UrunAd,
                                          Kategori = k.KategoriAd,
                                          Fiyat = u.Fiyat,
                                          Stok = u.Stok
                                      }).ToList();   
            return View(vm);
        }
        public IActionResult Ekle()
        {
            List<SelectListItem> degerler = (from i in _context.Kategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KategoriAd,
                                                 Value = i.KategoriId.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public IActionResult Ekle(Urun model)
        {
            if (ModelState.IsValid)
            {
                _context.Urunler.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View(model);
        }
        public IActionResult Kaldir(int id)
        {
            var urun = _context.Urunler.Find(id);
            if(urun is not null)
            {
                _context.Remove(urun);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Guncelle(int id)
        {
            var urun = _context.Urunler.Find(id);
            List<SelectListItem> degerler = (from i in _context.Kategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KategoriAd,
                                                 Value = i.KategoriId.ToString()
                                             }).ToList();
            ViewBag.urun = degerler;
            return View("Guncelle", urun);
        }
        [HttpPost]
        public IActionResult Guncelle(int id,Urun model)
        {
            var urun = _context.Urunler.Find(id);
            if (ModelState.IsValid)
            {
                urun.UrunAd = model.UrunAd;
                urun.UrunKategori = model.UrunKategori;
                urun.Fiyat = model.Fiyat;
                urun.Stok = model.Stok;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
