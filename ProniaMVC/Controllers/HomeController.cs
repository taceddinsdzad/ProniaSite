using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaMVC.DAL;
using ProniaMVC.Models;
using ProniaMVC.ViewModels;

namespace ProniaMVC.Controllers
{
    public class HomeController : Controller
    {

        public readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            Product product = new();



            HomeVM homeVM = new HomeVM()
            {
                //Slides = slides.OrderBy(s => s.Order).Take(2).ToList()
                Slides = await _context.Slides
                .Where(p => p.IsDeleted == false)
                .OrderBy(s => s.Order)
                .Take(2)
                .ToListAsync(),

                Products = await _context.Products
                .Where(p => p.IsDeleted == false)
                .Take(8)
                .Include(p => p.ProductImages
                .Where(pi => pi.IsPrimary != false))
                .ToListAsync()
            };

            return View(homeVM);
        }
    }
}
