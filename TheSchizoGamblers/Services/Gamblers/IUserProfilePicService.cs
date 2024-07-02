using Microsoft.AspNetCore.Identity;
using TheSchizoGamblers.Models.ViewModels;

namespace TheSchizoGamblers.Services.Gamblers
{
    public interface IUserProfilePicService
    {
        Task<string> GetProfilePic(string name);
    }
}