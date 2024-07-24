using System.ComponentModel.DataAnnotations;

namespace BiblioAPI.Models
{
    public class Biblioteca
    {
        public int Id { get; set; }
        public List<Libro> misLibros { get; set; } = null;
    }

    public class Libro
    {
        public int Id { get; set; }
        public string? name { get; set; }

        public string? description { get; set; }
        public string? auth { get; set; }
        public string? yearOfPublished { get; set; }
    }
}
