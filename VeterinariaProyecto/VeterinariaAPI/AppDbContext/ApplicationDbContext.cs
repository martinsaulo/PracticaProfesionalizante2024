using Microsoft.EntityFrameworkCore;
using VeterinariaAPI.Models;

namespace VeterinariaAPI.AppDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Animal> Animales { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Atencion> Atenciones { get; set;}
    }
}
