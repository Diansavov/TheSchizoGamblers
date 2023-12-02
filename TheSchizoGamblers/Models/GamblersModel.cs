using Microsoft.AspNetCore.Identity;

namespace TheSchizoGamblers.Models
{
    public class GamblersModel : IdentityUser
    {
        public DateTime DateOfBirth { get; set; }
    }
}
