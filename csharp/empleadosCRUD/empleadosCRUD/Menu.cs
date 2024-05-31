using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace empleadosCRUD
{
    internal class Menu
    {

        public Menu() { 
        //constructor vacio
        }
        public void getMenu() {
            
            Console.WriteLine("----------- MENU ----------");
            Console.WriteLine("1.- alta empleado");
            Console.WriteLine("2.- alta departamento");
            Console.WriteLine("3.- eliminar empleado by codigo");
            Console.WriteLine("4.- eliminar departamento by codigo");
            Console.WriteLine("5.- modificar empleado , cambio de departamento by cod empleado");
            Console.WriteLine("6.- modificar departamento, asignar nuevo presupuesto by cod departamento");
            Console.WriteLine("7.- modificar departamento, asignar nuevos gastos by cod departamento");
            Console.WriteLine("----------------INFORMES-----------------");
            Console.WriteLine("5.- informe empleados (todos)");

            int opcion = int.Parse(Console.ReadLine());

            ejecutarOperacion(opcion);
        }

        public void ejecutarOperacion(int opcion) {
            SGBD sgbd = new SGBD();
            sgbd.openConn();
            switch (opcion) {
                case 1:
                    //recogida de datos
                    Console.WriteLine("Vas a añadir un empleado");
                    Console.WriteLine("introduce el nif del nuevo empleado");
                        string nif = Console.ReadLine();    
                    Console.Write("como se llama?");
                        string nombre = Console.ReadLine();
                    Console.WriteLine("cual es primer apellido?");
                        string apellido1 = Console.ReadLine();  
                    Console.WriteLine("cual es segundo apellido?");
                        string apellido2 = Console.ReadLine();
                    Console.WriteLine("introduce el numero de departamento");
                        int cod = int.Parse(Console.ReadLine());
                    //SGBD mysql
                    sgbd.insertEmpleado(new Empleado(nif,nombre, apellido1, apellido2, cod));
                    sgbd.closeConn();
                    break;
                case 2:
                    Console.WriteLine("Vas a crear un departamento");


                    Console.WriteLine("introduce el nombre del nuevo departamento");
                    nombre = Console.ReadLine();

                    Console.WriteLine("introduce el presupuesot de departamento");
                    double presupuesto = double.Parse(Console.ReadLine());

                    Console.WriteLine("introduce los gastos de departamento");
                    double gastos = double.Parse(Console.ReadLine());

                    sgbd.insertDepartamento(new Departamento(nombre, presupuesto, gastos));
                    sgbd.closeConn();
                    break;
                //TODO add cases

                case 3:
                    Console.WriteLine("escribe el codigo del empleado que deseas eliminar.");
                    cod = int.Parse(Console.ReadLine());
                    sgbd.deletingEmpleado(cod);
                    sgbd.closeConn();
                    break;
                case 4:
                    Console.WriteLine("escribe el codigo del departmaento que deseas elimnar");
                    cod = int.Parse(Console.ReadLine());
                    sgbd.deletingEmpleado(cod);
                    sgbd.closeConn();
                    break;
                case 7:
                    Console.WriteLine("INFORME EMPLEADOS EMPLEADOS (nombre y apellidos)");
                    sgbd.readEmpleados();
                    sgbd.closeConn();
                    break;
                case 8:
                    Console.WriteLine("INFORME DEPARTAMENTOS (Nombre y presupuesto)");    
                    break;
                default:
                    Console.WriteLine("opcion no disponible");
                    break;
            }
        }
    }
}
