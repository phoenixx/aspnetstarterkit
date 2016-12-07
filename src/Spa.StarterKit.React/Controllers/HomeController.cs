using Microsoft.AspNetCore.Mvc;

namespace Spa.StarterKit.React.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}