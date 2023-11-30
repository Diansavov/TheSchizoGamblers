using Microsoft.EntityFrameworkCore;
using TheSchizoGamblers.Models;

namespace TheSchizoGamblers.Data
{
    public class GamblersContext : DbContext
    {
        public GamblersContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<GamblersModel> Gamblers { get; set; }
    }
}
