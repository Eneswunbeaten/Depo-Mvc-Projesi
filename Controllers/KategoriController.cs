using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcStok.Data;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        private readonly StokDbContext _context;
        public KategoriController(StokDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var kategori=_context.Kategoriler.ToList();
            return View(kategori);
        }
        public IActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ekle(Kategori model)
        {
            if (ModelState.IsValid)
            {
                _context.Kategoriler.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Kaldir(int id)
        {
            var kategori = _context.Kategoriler.Find(id);
            if(kategori is not null)
            {
                _context.Kategoriler.Remove(kategori);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Guncelle(int id)
        {
            var kategori = _context.Kategoriler.Find(id);
            return View("Guncelle",kategori);
        }
        [HttpPost]
        public IActionResult Guncelle(int id,Kategori model)
        {
            var kategori = _context.Kategoriler.Find(id);
            
            if (ModelState.IsValid)
            {
                kategori.KategoriAd=model.KategoriAd;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View("Getir");
        }
    }
}
