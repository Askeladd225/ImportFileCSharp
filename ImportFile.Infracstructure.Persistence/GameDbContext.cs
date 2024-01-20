

using ImportFile.WebApi.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace ImportFile.Infracstructure.Persistence
{
    public class GameDbContext :DbContext
    {

       public GameDbContext(DbContextOptions<GameDbContext> options) : base(options) { }

        public DbSet<Game> Games { get; set; }
    }
}