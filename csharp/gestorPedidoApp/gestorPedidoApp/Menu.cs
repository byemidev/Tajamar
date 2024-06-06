using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
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
            GestionProducto gestorProducto = new GestionProducto();

            int i = 0;

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
                        i = int.Parse(Console.ReadLine());
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
                        i = int.Parse(Console.ReadLine());
                        if (i == 1)
                        {
                            pedido.cliente = gestorCliente.recogerCliente();
                            gestorCliente.altaCliente(conexion_aux, pedido.cliente);
                        }
                    }
                    //TODO: 
                    /* 1.- Mostrar productos gestionProductos.cargarProductos()
                     * 2.- Seleccionar productos en do while "agregar producto o pagar"
                     *      2.1- dentro de cada seleccion ir creando obejetos cabecera y detalle de cabecera 
                     */
                    gestorProducto.cargarProductos(conexion_aux);

                    
                    Console.WriteLine("-------------- SELECTOR DE PRODUCTOS -----------------");

                    bool salir = false;
                    do {
                        Console.WriteLine("Selecciona un producto, escribe el id del producto");
                        pedido.listaProductos.Add(new Producto(int.Parse(Console.ReadLine())));

                        Console.WriteLine("1.- Seguir añadiendo \n 2.- Salir ");
                        i = int.Parse(Console.ReadLine());
                        if (!salir && i == 2)
                        {
                            salir = true;
                        }
                    } while (!salir);


                    //crear cabeceras y detalles de cabecera de lista de productos por id llamar al procedimiento almacenado
                    GestionCabecera gestorCabecera = new GestionCabecera();

                    pedido.listaProductos.ForEach((Producto) => { 
                        int i = gestorCabecera.insertarCabeceras(conexion_aux, pedido.cliente, pedido.metodo, pedido.fecha);
                    });

                    //gestorDetalleCabeceraPedido.insertarDetalles(pedido.listaProductos);
                    
                    Console.WriteLine("Como desea pagar");


                    //cargarForma de pago 
                    //gestorMetodoPago.listarMetodos();

                    //pedido.metodoPago = asignar objeto de forma de pago;
                    
                    

                    break;

                default:
                    Console.WriteLine("Opcion no disponible");
                    break;
            }
        }
        
    }
}
