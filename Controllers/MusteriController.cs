using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MvcStok.Data;
using MvcStok.Models.Entity;
using NuGet.Protocol.Core.Types;

namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        private readonly StokDbContext _context;
        public MusteriController(StokDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var musteri=_context.Musteriler.ToList();
            return View(musteri);
        }
        public IActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ekle(Musteri model)
        {
            if(ModelState.IsValid)
            {
                _context.Musteriler.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
        public IActionResult Kaldir(int id)
        {
            var musteri = _context.Musteriler.Find(id);
            if(musteri is not null)
            {
                _context.Remove(musteri);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Guncelle(int id)
        {
            var musteri=_context.Musteriler.Find(id);
            return View("Guncelle", musteri);
        }
        [HttpPost]
        public IActionResult Guncelle(int id,Musteri model)
        {
            var musteri = _context.Musteriler.Find(id);
            if (ModelState.IsValid)
            {
                musteri.MusteriAd = model.MusteriAd;
                musteri.MusteriSoyad = model.MusteriSoyad;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View(model);
        }

    }
}