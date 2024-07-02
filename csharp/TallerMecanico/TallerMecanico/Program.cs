using TallerMecanico.VIEW;

namespace TallerMecanico {
    internal class Program { 
        public static void Main(string[] args)
        {
            bool salir = false;

            Menu menu = new Menu();
            do { 
                menu.getMenu();
                Console.WriteLine("---------------------------------------------------------------------");
                Console.WriteLine("1.- SALIR    \n2.- REALIZAR OTRA OPERACION");
                int option = int.Parse(Console.ReadLine());
                if (option != 1)
                {
                    continue;
                }
                else { 
                    salir = true;   
                }
            } while (!salir);
        }
    }
}