
using TallerMecanico.MODEL;

namespace TallerMecanico.CONTROLLER
{
    internal class Trabajo_implController
    {

        private readonly List<Mecanico> trabajosMecanicos;
        private readonly List<ChapaPintura> trabajosChapa;

        public Trabajo_implController() { 
            this.trabajosMecanicos = new List<Mecanico>();
            this.trabajosChapa = new List<ChapaPintura>();  
        }

        public void crearTrabajo() {
            Console.WriteLine("--------------------- TIPO DE TRABAJO --------------------");
            Console.WriteLine("1.- Mecanico");
            Console.WriteLine("2.- Chapa y Pintura.");

            int option = int.Parse(Console.ReadLine());

            switch (option) {
                case 1:
                    Console.WriteLine("creando trabajo.... ");

                    Console.WriteLine("Descripcion del trabajo mecanico:\n");
                    string desc = Console.ReadLine();
                    
                    Console.WriteLine("Horas estimadas para realizar el trabajo:\n");
                    int horas = int.Parse(Console.ReadLine());
                    
                    trabajosMecanicos.Add(new Mecanico(desc, horas));
                    break;
                case 2:
                    break;
                default:
                    Console.WriteLine("No existe esa opcion");
                    break;
            }
        }
    }
}
