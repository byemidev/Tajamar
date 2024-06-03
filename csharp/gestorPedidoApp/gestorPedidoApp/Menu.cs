using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestorPedidoApp
{
    internal class Menu
    {
        public Menu() {
           //constructor vacio
        }


        public  void getMenu() {
            Console.WriteLine("--------------- MENU -------------");
            Console.WriteLine("1.- Listar pedido");
            Console.WriteLine("2.- alta cliente");
            Console.WriteLine("3.- alta pedido"); //TODO: preguntar por id cliente, si no existe -> alta ,
                                                  //capturar datos en objeto pedido e insertar en cada tabla los datos de forma correcta
            
            int opcion = int.Parse(Console.ReadLine());

            execute(opcion);
        }

        private  void execute (int opcion) {

            GestionPedido gestor = new GestionPedido();

            switch (opcion)
            {

                case 1:
                    Console.WriteLine("listando los pedidos...");
                    gestor.mostrarPedidos();
                    break;

                case 2:
                    Console.WriteLine("dando alta ....");
                    gestor.altaCliente();
                    break;
                default:
                    Console.WriteLine("Opcion no disponible");
                    break;
            }
        }
    
    }
}
