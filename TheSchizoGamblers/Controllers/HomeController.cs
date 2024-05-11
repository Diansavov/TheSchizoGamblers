using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TheSchizoGamblers.Models;
using TheSchizoGamblers.Models.ViewModels;

namespace TheSchizoGamblers.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<GamblersModel> _userManager;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, UserManager<GamblersModel> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            GamblersModel user = await _userManager.FindByNameAsync(User.Identity.Name);

            ProfilePicViewModel profilePic = new ProfilePicViewModel(user.PictureSource);

            return View(profilePic);
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}