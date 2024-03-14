using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TheSchizoGamblers.Data;
using TheSchizoGamblers.Models;
using TheSchizoGamblers.Models.Games;
using TheSchizoGamblers.Models.ViewModels;


namespace TheSchizoGamblers.Controllers
{
    [Authorize]
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
            SlotsModel slots = new SlotsModel();

            return View(slots);
        }
        [HttpPost]
        public async Task<IActionResult> Slots(SlotsModel slotsModel)
        {
            slotsModel.Randomize();

            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            user.Balance += slotsModel.CheckWin();

            await _gamblersContext.SaveChangesAsync();

            slotsModel.Money = Math.Round(user.Balance, 2);

            return View(slotsModel);
        }
    }
}
