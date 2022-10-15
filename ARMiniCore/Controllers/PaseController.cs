using Microsoft.AspNetCore.Mvc;

namespace ARMiniCore.Controllers
{
    public class PaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
