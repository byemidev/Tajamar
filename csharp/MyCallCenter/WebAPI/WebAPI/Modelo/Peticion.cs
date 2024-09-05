namespace WebAPI.Modelo
{
    public class Peticion
    {

        public string numero { get; set; }

        public int id { get; set; }

        public string Auth { get; set; }
    }

    public class Respuesta
    {
        public DateOnly? Date { get; set; }

        public string cola { get; set; }

        public int id { get; set; }

        public int error { get; set; }

    }
}
