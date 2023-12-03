using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TheSchizoGamblers.Data;
using TheSchizoGamblers.Models;
using TheSchizoGamblers.Models.ViewModels;

namespace TheSchizoGamblers.Controllers
{
    public class GamblersController : Controller
    {
        private readonly GamblersContext gamblersContext;
        private readonly UserManager<GamblersModel> _userManager;
        private readonly SignInManager<GamblersModel> _signInManager;

        public GamblersController(GamblersContext gamblersContext, UserManager<GamblersModel> userManager, SignInManager<GamblersModel> signInManager)
        {
            this.gamblersContext = gamblersContext;
            this._userManager = userManager;
            this._signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Gamblers()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Gamblers(GamblersViewModel addGamblerRequest)
        {
            GamblersModel user = new GamblersModel()
            {
                UserName = addGamblerRequest.Username,
                Email = addGamblerRequest.Email,
                DateOfBirth = addGamblerRequest.DateOfBirth
            };
            var result = await _userManager.CreateAsync(user, addGamblerRequest.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);

                return RedirectToAction("Index", "Home");
            }

            return View(addGamblerRequest);
        }
    }

}

