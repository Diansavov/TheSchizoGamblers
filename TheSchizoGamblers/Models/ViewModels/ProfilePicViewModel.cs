using System.Buffers.Text;
using System.ComponentModel.DataAnnotations;

namespace TheSchizoGamblers.Models.ViewModels
{
    public class ProfilePicViewModel
    {
        public string ProfilePicture { get; set; }
        public ProfilePicViewModel(byte[] imageBytes)
        {
            ProfilePicture = Convert.ToBase64String(imageBytes);
        }
    }
}
