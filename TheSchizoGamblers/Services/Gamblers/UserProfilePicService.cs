using Microsoft.AspNetCore.Identity;
using TheSchizoGamblers.Data;
using TheSchizoGamblers.Models;
using TheSchizoGamblers.Models.ViewModels;

namespace TheSchizoGamblers.Services.Gamblers
{
    class UserProfilePicService : IUserProfilePicService
    {
        private readonly UserManager<GamblersModel> _userManager;
        private readonly GamblersContext _contextManager;
        public UserProfilePicService(UserManager<GamblersModel> userManager, GamblersContext gamblersContext)
        {
            _userManager = userManager;
            _contextManager = gamblersContext;
        }
        public async Task<string> GetProfilePic(string name)
        {
            GamblersModel user = await _userManager.FindByNameAsync(name);
            GamblerPictureModel pictureUser = _contextManager.ProfilePictures.Where(u => u.User == user).FirstOrDefault();

            ProfilePicViewModel profilePic = new ProfilePicViewModel(pictureUser.PictureSource);

            return profilePic.ProfilePicture;
        }
    }
}