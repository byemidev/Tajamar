namespace MVCBiblioteca.Models
{
    public class Libro
    {
        public int Id { get; set; }
        public string? name { get; set; }

        public string? description { get; set; }
        public string? auth { get; set; }
        public string? yearOfPublished { get; set; }
    }
}
