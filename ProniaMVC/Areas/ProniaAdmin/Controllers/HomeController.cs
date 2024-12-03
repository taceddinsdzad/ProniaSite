using Microsoft.AspNetCore.Mvc;

namespace ProniaMVC.Areas.ProniaAdmin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
