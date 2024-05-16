using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TheSchizoGamblers.Data;
using TheSchizoGamblers.Models;
using TheSchizoGamblers.Models.ViewModels;

namespace TheSchizoGamblers.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<GamblersModel> _userManager;
        private readonly GamblersContext _contextManager;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, UserManager<GamblersModel> userManager, GamblersContext contextManager)
        {
            _logger = logger;
            _userManager = userManager;
            _contextManager = contextManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            GamblersModel user = await _userManager.FindByNameAsync(User.Identity.Name);
            GamblerPictureModel pictureUser = _contextManager.ProfilePictures.Where(u => u.User == user).FirstOrDefault();
            if (pictureUser == null)
            {
                ProfilePicViewModel profilePicTemp = new ProfilePicViewModel();
                return View(profilePicTemp);
            }
            ProfilePicViewModel profilePic = new ProfilePicViewModel(pictureUser.PictureSource);

            return View(profilePic);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}