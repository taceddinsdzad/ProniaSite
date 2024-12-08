using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaMVC.DAL;
using ProniaMVC.Models;

namespace ProniaMVC.Areas.Admin.Controllers
{
    [Area("admin")]
    public class SlideController : Controller
    {
        private readonly AppDbContext _context;

        public SlideController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Slide> slides = await _context.Slides.ToListAsync();
            return View(slides);

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Slide slide)
        {

            if (!slide.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "File type is incoorected");
                return View();
            }
            if (slide.Photo.Length > 2 * 1024 * 1024)
            {
                ModelState.AddModelError("Photo", "File size mast be less that 2 mb");
                return View();
            }



            return Content(slide.Photo.FileName + "   " + slide.Photo.ContentType + "     " + slide.Photo.Length);


            //if (!ModelState.IsValid) return View();

            //await _context.Slides.AddAsync(slide);
            //await _context.SaveChangesAsync();

            //return RedirectToAction(nameof(Index));

        }
    }
}
