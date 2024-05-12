using Microsoft.AspNetCore.Identity;

namespace TheSchizoGamblers.Models
{
    public class GamblerPictureModel
    {

        public GamblerPictureModel()
        {
            Id = Guid.NewGuid().ToString();
        }
        
        public string Id { get; set; }
        public byte[]? PictureSource { get; set; }
        public GamblersModel User { get; set; }
    }
}
