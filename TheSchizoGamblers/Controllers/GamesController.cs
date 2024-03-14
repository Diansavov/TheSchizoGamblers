using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TheSchizoGamblers.Data;
using TheSchizoGamblers.Models;
using TheSchizoGamblers.Models.Games;


namespace TheSchizoGamblers.Controllers
{
    public class GamesController : Controller
    {
        private readonly UserManager<GamblersModel> _userManager;
        private readonly GamblersContext _gamblersContext;

        public GamesController(UserManager<GamblersModel> userManager, GamblersContext gamblersContext)
        {
            this._userManager = userManager;
            this._gamblersContext = gamblersContext;
        }
        [HttpGet]
        public IActionResult Slots()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("LogIn", "Gamblers");
            }

            SlotsModel slots = new SlotsModel();

            return View(slots);
        }
        [HttpPost]
        public async Task<IActionResult> Slots(SlotsModel slotsModel)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("LogIn", "Gamblers");
            }

            slotsModel.Randomize();

            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            user.Balance += slotsModel.CheckWin();

            await _gamblersContext.SaveChangesAsync();

            slotsModel.Money = Math.Round(user.Balance, 2);

            return View(slotsModel);
        }
    }
}
