using Microsoft.AspNetCore.Identity;
using TheSchizoGamblers.Models.ViewModels;

namespace TheSchizoGamblers.Services.Gamblers
{
    public interface IGamblersService
    {
        Task<IdentityResult> Register(GamblersViewModel registerRequest);
        Task<SignInResult> LogIn(LogInViewModel logInRequest);
        Task LogOut();
    }
}