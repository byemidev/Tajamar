using Microsoft.EntityFrameworkCore;
using BiblioAPI.Models;

namespace BiblioAPI.Models
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { 
         //Nothing TODO
        }

        public DbSet<Biblioteca> bibliotecas { get; set; } = null; 
        public DbSet<BiblioAPI.Models.Libro> Libro { get; set; } = default!;
    }
}
