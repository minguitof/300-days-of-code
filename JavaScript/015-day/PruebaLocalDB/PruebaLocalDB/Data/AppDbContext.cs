using Microsoft.EntityFrameworkCore;
using PruebaLocalDB.Models;
using System.Collections.Generic;

namespace PruebaLocalDB.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
    }
}
