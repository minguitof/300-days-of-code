using Microsoft.EntityFrameworkCore;
using MyFirtsTest.Models; 

namespace MyFirtsTest.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
