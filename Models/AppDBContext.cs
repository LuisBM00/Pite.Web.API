using Microsoft.EntityFrameworkCore;

namespace Pite.Web.API.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options): base(options)
        {
            
        }

        public DbSet<Productos> productos { get; set; }
    }
}
