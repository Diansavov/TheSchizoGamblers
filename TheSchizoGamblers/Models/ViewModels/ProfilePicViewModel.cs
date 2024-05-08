using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace TheSchizoGamblers.Models.ViewModels
{
    public class ProfilePicViewModel
    {
        public Image ProfilePicture { get; set; }
        public ProfilePicViewModel(byte[] picture)
        {
            Image image = Image.Load<Rgba32>(picture);
            image.Mutate(x => x.Grayscale());

            ProfilePicture = image;
        }
    }
}
