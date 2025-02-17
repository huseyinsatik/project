using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project.Data;
using project.Models;

namespace project.Controllers
{
    public class InsureeController : Controller
    {
        private readonly InsuranceContext _context;

        public InsureeController(InsuranceContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Insuree insuree)
        {
            if (ModelState.IsValid)
            {
                // Teklif hesaplama
                decimal quote = 50; // Baz fiyat

                // Yaş hesaplama
                var age = DateTime.Now.Year - insuree.DateOfBirth.Year;
                if (insuree.DateOfBirth.Date > DateTime.Now.AddYears(-age)) age--;

                // Yaşa göre fiyat ekleme
                if (age <= 18)
                    quote += 100;
                else if (age <= 25)
                    quote += 50;
                else
                    quote += 25;

                // Araç yılına göre fiyat ekleme
                if (insuree.CarYear < 2000)
                    quote += 25;
                if (insuree.CarYear > 2015)
                    quote += 25;

                // Porsche kontrolü
                if (insuree.CarMake.ToLower() == "porsche")
                {
                    quote += 25;
                    if (insuree.CarModel.ToLower() == "911 carrera")
                        quote += 25;
                }

                // Hız cezaları için fiyat ekleme
                quote += insuree.SpeedingTickets * 10;

                // Alkollü araç kullanma sabıkası kontrolü
                if (insuree.HasDUI)
                    quote += quote * 0.25m;

                // Tam kapsamlı sigorta kontrolü
                if (insuree.IsFullCoverage)
                    quote += quote * 0.50m;

                insuree.Quote = quote;
                _context.Add(insuree);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(insuree);
        }

        public async Task<IActionResult> Admin()
        {
            return View(await _context.Insurees.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var insuree = await _context.Insurees.FindAsync(id);
            if (insuree != null)
            {
                _context.Insurees.Remove(insuree);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Admin));
        }
    }
} 