using System.ComponentModel.DataAnnotations;

namespace TheSchizoGamblers.Models.ViewModels
{
    public class LogInViewModel
    {
        [Required(ErrorMessage = "Username can't be empty")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password can't be empty")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
    }
}
