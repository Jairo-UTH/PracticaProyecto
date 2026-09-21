using BackendTienda.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendTienda.Shared.Database
{
    public class AppdbContext(DbContextOptions<AppdbContext> options) : DbContext(options)
    {
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Position> Position { get; set; }
    }
}
