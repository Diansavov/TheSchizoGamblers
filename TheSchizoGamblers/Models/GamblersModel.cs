using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TheSchizoGamblers.Models
{
    public class GamblersModel : IdentityUser
    {
        public DateTime DateOfBirth { get; set; }
        public decimal Balance { get; set; }
    }
}
