using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TheSchizoGamblers.Models.ViewModels;
using TheSchizoGamblers.Services.Gamblers;

namespace TheSchizoGamblers.Controllers
{
    public class GamblersController : Controller
    {
        private readonly IGamblersService _gamblersService;
        public GamblersController(IGamblersService gamblersService)
        {
            this._gamblersService = gamblersService;
        }

        [HttpGet]
        public IActionResult Gamblers()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Gamblers(GamblersViewModel addGamblerRequest)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await _gamblersService.Register(addGamblerRequest);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(addGamblerRequest);
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInViewModel addLogInRequest)
        {
            if (ModelState.IsValid)
            {
                var result = await _gamblersService.LogIn(addLogInRequest);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(addLogInRequest);
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            await _gamblersService.LogOut();

            return RedirectToAction("Index", "Home");
        }
    }
}