using Microsoft.AspNetCore.Mvc;
using TheSchizoGamblers.Models;

namespace TheSchizoGamblers.Controllers
{
    public class GamblersController : Controller
    {
        public IActionResult Gamblers()
        {
            GamblersModel gamblersModel = new GamblersModel("Gunter");
            return View(gamblersModel);
        }
    }
}
