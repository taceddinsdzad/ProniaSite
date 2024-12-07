using Microsoft.AspNetCore.Mvc;

namespace ProniaMVC.Areas.ProniaAdmin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
