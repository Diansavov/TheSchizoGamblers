using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TheSchizoGamblers.Data;
using TheSchizoGamblers.Models;

namespace TheSchizoGamblers.Controllers
{
    public class ProfileController : Controller
    {
        private readonly GamblersContext _gamblersContext;
        private readonly UserManager<GamblersModel> _userManager;

        public ProfileController(UserManager<GamblersModel> userManager, GamblersContext gamblersContext)
        {
            this._userManager = userManager;
            this._gamblersContext = gamblersContext;
        }

        [HttpGet]
        public IActionResult UserProfile()
        {
            return View();
        }
        [HttpGet]
        public IActionResult UserProfile2()
        {
            return View();
        }


    }
}