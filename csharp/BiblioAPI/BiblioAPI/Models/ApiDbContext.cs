using Microsoft.EntityFrameworkCore;

namespace BiblioAPI.Models
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { 
         //Nothing TODO
        }

        public DbSet<Biblioteca> bibliotecas { get; set; } = null; 
        public DbSet<Libro> Libro { get; set; } = default!;
    }
}
