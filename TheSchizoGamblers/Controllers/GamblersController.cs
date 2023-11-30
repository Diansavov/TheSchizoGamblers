using Microsoft.AspNetCore.Mvc;
using TheSchizoGamblers.Models;

namespace TheSchizoGamblers.Controllers
{
    public class GamblersController : Controller
    {
        public IActionResult Gamblers()
        {
            return View();
        }
    }
}
