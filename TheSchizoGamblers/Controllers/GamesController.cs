using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TheSchizoGamblers.Models.Games;


namespace TheSchizoGamblers.Controllers
{
    public class GamesController : Controller
    {

        [HttpGet]
        public IActionResult Slots()
        {
            SlotsModel slots = new SlotsModel();

            return View(slots);
        }

        [HttpPost]
        public IActionResult Slots(SlotsModel slotsModel)
        {
            slotsModel.Randomize();

            return View(slotsModel);
        }

    }
}
