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
            Random random = new Random();

            for (int i = 0; i < slotsModel.NumbersArray.Length; i++)
            {
                slotsModel.NumbersArray[i] = random.Next(1, 2);
            }

            return View(slotsModel);
        }

    }
}