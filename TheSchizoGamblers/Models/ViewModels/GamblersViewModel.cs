using System.ComponentModel.DataAnnotations;

namespace TheSchizoGamblers.Models.ViewModels
{
    public class GamblersViewModel
    {
        [DataType(DataType.Upload)]
        public IFormFile? ProfilePic { get; set; }

        [Required(ErrorMessage = "Username can't be empty")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email can't be empty")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password can't be empty")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Date of Birth can't be empty")]
        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }
    }
}
