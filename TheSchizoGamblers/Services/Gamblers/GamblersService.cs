using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using TheSchizoGamblers.Data;
using TheSchizoGamblers.Models;
using TheSchizoGamblers.Models.ViewModels;

namespace TheSchizoGamblers.Services.Gamblers
{
    class GamblersService : IGamblersService
    {
        private readonly GamblersContext _gamblersContext;
        private readonly UserManager<GamblersModel> _userManager;
        private readonly SignInManager<GamblersModel> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public GamblersService(GamblersContext gamblersContext, UserManager<GamblersModel> userManager,
         SignInManager<GamblersModel> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this._gamblersContext = gamblersContext;
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._roleManager = roleManager;
        }

        public async Task<IdentityResult> Register(GamblersViewModel registerRequest)
        {
            GamblersModel user = new GamblersModel()
            {
                UserName = registerRequest.Username,
                Email = registerRequest.Email,
                DateOfBirth = registerRequest.DateOfBirth
            };

            GamblerPictureModel pictureUser = new GamblerPictureModel()
            {
                User = user
            };

            using (var memoryStream = new MemoryStream())
            {
                await registerRequest.ProfilePic.CopyToAsync(memoryStream);

                // Upload the file if less than 2 MB  
                if (memoryStream.Length < 2097152)
                {
                    pictureUser.PictureSource = memoryStream.ToArray();
                }
            }

            var result = await _userManager.CreateAsync(user, registerRequest.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                await _signInManager.SignInAsync(user, isPersistent: false);
                await _gamblersContext.AddAsync(pictureUser);
                await _gamblersContext.SaveChangesAsync();
            }
            return result;
        }
        public async Task<SignInResult> LogIn(LogInViewModel logInRequest)
        {
            var user = await _userManager.FindByNameAsync(logInRequest.Username);

            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, logInRequest.Password);

                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, logInRequest.Password, false, false);
                    return result;
                }
            }

            return SignInResult.Failed;
        }

        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }

    }

}
