
namespace TallerMecanico.MODEL
{
    public class Trabajo_impl : Trabajo
    {

        public int id { get; set; }
        public string descripcion { get; set; }

        public int num_horas { get; set; }

        public bool finalizado { get; set; }


        public Trabajo_impl() { }

        public Trabajo_impl(string descripcion, int num_horas)
        {
            this.descripcion = descripcion;
            this.num_horas = num_horas;
            this.finalizado = false;
        }


        public override string ToString()
        {
            return "Id: " + this.id + "\nDescripcion: " + this.descripcion + "\nNumero horas: " + this.num_horas + "\nFinalizado: " + this.finalizado;
        }

        //metodo para cambiar las horas de un objeto seleccionado 
        public void modificarHorasTrabajo(int horas, Trabajo_impl trabajo) { 
            trabajo.num_horas += horas;
        }

        //metodo pra recuperar el id de los trabajos == index que ocupan en el array v.001

        public int getTrabajoId(List<Trabajo_impl> trabajos) {
            trabajos.ForEach((trabajo)=> {
                trabajo.id = trabajos.IndexOf(trabajo);
                Console.WriteLine(trabajo.ToString());   
            });

            Console.WriteLine("Escribe el Id del tabajo que deseas obetener...");
            int id = int.Parse(Console.ReadLine());

            return id;
        }   


        public void finalizarTrabajo(Trabajo_impl trabajo)
        {
            trabajo.finalizado = true;
        }

    }
}
