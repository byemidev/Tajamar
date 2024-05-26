using HospitalApp_v_0_2.Model;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace HospitalApp_v_0_2
{ 
    internal class Program : Hospital
    {
        public static void Main(string[] args) { 

            //TODO: instancia de hospital 
            List<Cita> citas = new List<Cita>();

            //TODO: menu - 1.- Alta cita, 2.- Baja Cita 3.- Buscar Paciente con cita 4.- salir
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("---------------------------------MENU GESTION CITAS---------------------------------");
                Console.WriteLine("#1.-  DAR ALTA CITA");
                Console.WriteLine("#2.-  DAR BAJA CITA");
                Console.WriteLine("#3.-  Buscar cita por paciente");
                Console.WriteLine("#0.-  SALIR");

                int opcion = int.Parse(Console.ReadLine());

                //switching
                switch (opcion) {
                    case 1: Console.WriteLine("Vas a dar una cita de alta");
                        citas.Add(alta_cita());           
                        break;

                    case 2: Console.WriteLine("Vas a dar de baja una cita");
                        Console.WriteLine("Escriba el id de paciente que desea eliminar");

                        break;  

                    case 3: Console.WriteLine("Vas a buscar un paciente\nIntroduce el dni(SOLO NUMEROS) del paciente para ver el historial de citas");
                        try
                        {
                            //recoger datos (int) 
                            int dni = int.Parse(Console.ReadLine());
                            //TOOD: llamar a metodo correspondiente 
                            Paciente paciente =  buscar_paciente(citas, dni);
                            Console.WriteLine(paciente.ToString());
                        }
                        catch(Exception e)
                        { 
                            Console.WriteLine($"MENSAJE DE ERROR{e.Message}");  
                        }
                        break;
                    case 0: Console.WriteLine("SALIENDO....");
                        Thread.Sleep(1500);//saliendo en 1.5s
                        salir = true;
                        break;
                }//end switch
            }//end while
            Environment.Exit(0);
        }//en main
    }

}