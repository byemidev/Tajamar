using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace gestorPedidoApp
{
    internal class Menu
    {
        private MySqlConnection conexion_aux;
        public Menu(Conexion conexion) {
           //constructor vacio
           conexion_aux = conexion.getConn(); 
        }


        public  void getMenu() {
            Console.WriteLine("--------------- MENU -------------");
            Console.WriteLine("1.- Listar pedido");
            Console.WriteLine("2.- alta cliente");
            Console.WriteLine("3.- alta pedido"); //TODO: preguntar por id cliente, si no existe -> alta ,
                                                  //capturar datos en objeto pedido e insertar en cada tabla los datos de forma correcta
            
            int opcion = int.Parse(Console.ReadLine());

            execute(conexion_aux, opcion);
        }

        private  void execute (MySqlConnection conexion , int opcion) {

            GestionPedido gestorPedido = new GestionPedido();
            GestionCliente gestorCliente = new GestionCliente();  

            switch (opcion)
            {

                case 1:
                    Console.WriteLine("listando los pedidos...");
                    gestorPedido.mostrarPedidos(conexion);
                    break;

                case 2:
                    
                    Cliente cliente = gestorCliente.recogerCliente();
                    
                    if (gestorCliente.clienteExiste(conexion_aux, cliente.telefono) != true)
                    {
                        gestorCliente.altaCliente(conexion_aux, cliente);
                    }
                    else {
                        Console.WriteLine("Ya existe un cliente con este numero de telefono");
                        Console.WriteLine("Desea continuar con otro numero de telefono?\n 1.- SI\n 2.- NO");
                        int i = int.Parse(Console.ReadLine());
                        if (i == 1) {
                            Console.WriteLine("Inserte el nuevo numero de telefono");
                            cliente.telefono = Console.ReadLine();
                            gestorCliente.altaCliente(conexion_aux, cliente);
                        } else if (i ==2) { 
                            Console.WriteLine("Intenta dar de alta otro nuevo cliente o modifique los datos del cliente");    
                        }else
                        {
                            Console.WriteLine("Ninguna opcion valida elegida");
                        }
                    }
                    break;

                case 3:
                    //instancing pedido
                    Pedido pedido = new Pedido();   

                    Console.WriteLine("A que cliente quieres asignar el pedido?. Introduce el numero de telefono?");
                    string telefono = Console.ReadLine();
                    if (gestorCliente.clienteExiste(conexion_aux, telefono) == true)
                    {
                        pedido.cliente = gestorCliente.cargarCliente(conexion_aux, telefono);
                    }
                    else {
                        Console.WriteLine("El cliente no exite desea: \n1.- Crear un cliente nuevo \n\n");
                        int i = int.Parse(Console.ReadLine());
                        if (i == 1)
                        {
                            pedido.cliente = gestorCliente.recogerCliente();
                            gestorCliente.altaCliente(conexion_aux, pedido.cliente);
                        }
                    }

                    

                    break;
                default:
                    Console.WriteLine("Opcion no disponible");
                    break;
            }
        }
    
    }
}
