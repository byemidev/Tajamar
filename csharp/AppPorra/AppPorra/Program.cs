using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace AppPorra
{
    internal class app : Controller.Apostante_Controller { 

        static List<Model.Apostante> apuestas = new List<Model.Apostante>();   

        public static void Main(String [] args)
        {
            bool salir = false;//para condicion de salida do while(!salir)
            do//principio do while()
            {
                Console.WriteLine("----------- APP PORRA");
                Console.WriteLine("----------- #1 hacer apuesta");
                Console.WriteLine("----------- #2 resultado porra");
                Console.WriteLine("----------- #3 ver apuestas");
                Console.WriteLine("----------- #0 salir");

                int opcion = -1;

                try
                {
                     opcion = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
                finally {
                    switch (opcion)
                    {
                        case 0:
                            Console.WriteLine("SALIENDO");
                            string puntuaciones = "";
                            char puntuacion = '.';
                            for (int i = 0; i <= 9; i++)
                            {
                                Thread.Sleep(400);
                                puntuaciones += " " + puntuacion;
                                Console.Write(puntuaciones);
                            }
                            salir = true;
                            break;
                        case 1:
                            Console.WriteLine("VAS A HACER UNA APUESTA");
                            Console.WriteLine("************ MADRID vs. BAYERN ****************");
                            Console.WriteLine("Que va a ocurrir esta noche de champions? ejej..");

                            Console.WriteLine("Escribe tu nombre por consola: ");
                            String nombre_apostante = Console.ReadLine();

                            Console.WriteLine("escribe los goles que metera el Madrid.");
                            int goles_madrid = int.Parse(Console.ReadLine());

                            Console.WriteLine("escribe los goles que metera el Bayern.");
                            int goles_bayern = int.Parse(Console.ReadLine());

                            hacerUnaApuesta(apuestas, nombre_apostante, goles_madrid, goles_bayern);
                            break;

                        case 2:
                            Console.WriteLine("VAS A MOSTRAR RESULTADO");
                            //En base al resultado... 
                            int resultado_goles_madrid = 0;
                            int resultado_goles_bayern = 3;
                            //mostrar los ganadores
                            mostrar_ganadores_premio(apuestas, resultado_goles_madrid, resultado_goles_bayern);
                            break;
                        case 3:
                            Console.WriteLine("LISTA DE APUESTA");
                            listar_apuestas(apuestas);  
                            break;
                        default:
                            Console.WriteLine("Esta opcion no esta disponible");
                            break;
                    }
                }
            } while (!salir);
            Environment.Exit(0);
        }//fin main
    }//end class
}