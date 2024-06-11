namespace BibliotecaAppWeb.Models
{
    public class Libro
    {
        public Guid id { get; set; }
        public string isbn { get; set; }
        public string titulo { get; set; }
        public string editorial { get; set; }
        public string genero { get; set; }
        public string idioma { get; set; } 
    }
}
