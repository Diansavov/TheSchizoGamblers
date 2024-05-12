using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TheSchizoGamblers.Models;

namespace TheSchizoGamblers.Data
{
    public class GamblersContext : IdentityDbContext<GamblersModel>
    {
        public GamblersContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<GamblersModel> Gamblers { get; set; }
        public DbSet<GamblerPictureModel> ProfilePictures { get; set; }
    }
}
