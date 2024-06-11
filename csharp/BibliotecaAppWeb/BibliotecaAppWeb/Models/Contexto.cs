using Microsoft.EntityFrameworkCore;


namespace BibliotecaAppWeb.Models
{

    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        // Agrega tus DbSet para cada entidad en tu base de datos
        public DbSet<Libro> misLibros { get; set; }
    }
}