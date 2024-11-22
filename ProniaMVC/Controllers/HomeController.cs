using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {

            List<Slide> slides = new List<Slide>
            {
              new Slide
              {
                  Title="Bashliq 1",
                  SubTitle="Komekci bashliq 1",
                  Description="Gulden al razi qal",
                  Image="1-1-524x617.png",
                  Order=1,
                  IsDeleted=false,
                  CreatAt=DateTime.Now
              },
              new Slide
              {
                  Title="Bashliq 2",
                  SubTitle="Komekci bashliq 2",
                  Description="Gulden al razi qal",
                  Image="1699458136_rosen-messi-miami.jpg",
                  Order=2,
                  IsDeleted=false,
                  CreatAt=DateTime.Now
              },
              new Slide
              {
                  Title="Bashliq 3 ",
                  SubTitle="Komekci bashliq 3",
                  Description="Gulden al razi qal",
                  Image="Messi_vs_Nigeria_2018.jpg",
                  Order=3,
                  IsDeleted=false,
                  CreatAt=DateTime.Now
              }
            };
            //_context.Slides.AddRange(slides);
            //_context.SaveChanges();
            HomeVM homeVM = new HomeVM()
            {
                //Slides = slides.OrderBy(s => s.Order).Take(2).ToList()
                Slides = _context.Slides.OrderBy(s => s.Order).Take(2).ToList(),
            };

            return View(homeVM);
        }
    }
}
