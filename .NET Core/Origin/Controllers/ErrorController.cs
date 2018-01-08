using Microsoft.AspNetCore.Mvc;

namespace Origin.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}