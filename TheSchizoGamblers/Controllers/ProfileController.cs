using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TheSchizoGamblers.Data;
using TheSchizoGamblers.Models;

namespace TheSchizoGamblers.Controllers
{
    [Authorize]
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
        public IActionResult About()
        {
            return View();
        }
        [HttpGet]
        public IActionResult PublicProfile()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Account()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Deposit()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Withdraw()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CardManagment()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Transactions()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Bets()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ResetPassword()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ChangeEmail()
        {
            return View();
        }
    }
}