using Microsoft.EntityFrameworkCore;


namespace Inmobiliaria.Models
{

    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        // Agrega tus DbSet para cada entidad en tu precio_base de datos
        public DbSet<Inmueble> Inmuebles { get; set; } // Base class DbSet

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 

            modelBuilder.Entity<Inmueble>()
                .HasDiscriminator<string>("Tipo") // el discriminador asigna un "tipo" con el nombre de .HasValue<Class>()
                .HasValue<Piso>("Piso")
                .HasValue<Local>("Local");

            modelBuilder.Entity<Piso>();
            modelBuilder.Entity<Local>();
        }
    }
}