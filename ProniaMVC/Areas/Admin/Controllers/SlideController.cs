﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaMVC.Areas.Admin.ViewModel.Slides;
using ProniaMVC.DAL;
using ProniaMVC.Models;
using ProniaMVC.Utilities.Extensions;

namespace ProniaMVC.Areas.Admin.Controllers
{
    [Area("admin")]
    public class SlideController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SlideController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
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
        public IActionResult Test()
        {
            return Content(Guid.NewGuid().ToString());
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateSlideVM slideVm)
        {

            if (!slideVm.Photo.ValidateType("image/"))
            {
                ModelState.AddModelError("Photo", "File type is incoorected");
                return View();
            }
            if (!slideVm.Photo.ValidateSize(Utilities.Enums.FileSize.Mb, 2))
            {
                ModelState.AddModelError("Photo", "File size mast be less that 2 mb");
                return View();
            }
            Slide slide = new Slide()
            {
                Title = slideVm.Title,
                SubTitle = slideVm.SubTitle,
                Description = slideVm.Description,
                Order = slideVm.Order,
                Image = await slideVm.Photo.CreateFileAsync(_env.WebRootPath, "assets", "images", "website-images"),
                IsDeleted = false,
                CreatAt = DateTime.Now
            };







            //if (!ModelState.IsValid) return View();

            await _context.Slides.AddAsync(slide);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id < 1) return BadRequest();
            Slide slide = await _context.Slides.FirstOrDefaultAsync(s => s.Id == id);
            if (slide == null) return NotFound();
            slide.Image.DeleteFile(_env.WebRootPath, "assets", "images", "website-images");
            _context.Slides.Remove(slide);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }
    }
}
