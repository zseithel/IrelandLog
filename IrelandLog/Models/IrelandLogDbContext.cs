using Microsoft.EntityFrameworkCore;

namespace IrelandLog.Models
{
    public class IrelandLogDbContext : DbContext
    {
        public IrelandLogDbContext(DbContextOptions<IrelandLogDbContext> options): base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Pic> Pics { get; set; }
    }    
}
