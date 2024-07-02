
using TallerMecanico.CONTROLLER;

namespace TallerMecanico.VIEW
{
    internal class Menu
    {
        public void getMenu() {
            Console.WriteLine("--------------------------MENU-------------------------");
            Console.WriteLine("1.- Registrar Trabajo");
            Console.WriteLine("2.- Mostrar trabajos");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            int option = int.Parse(Console.ReadLine());

            Console.WriteLine("\n");

            Trabajo_implController controller = new Trabajo_implController();

            switch (option) {
                case 1:
                    controller.crearTrabajo();
                    break;
                case 2:
                    controller.mostrarTrabajos();    
                    break;
            }
        }
    }
}
