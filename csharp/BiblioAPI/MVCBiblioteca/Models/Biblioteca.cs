namespace MVCBiblioteca.Models
{
    public class Biblioteca
    {
        public int Id { get; set; }
        public List<Libro> misLibros { get; set; } = null;
    }
}
