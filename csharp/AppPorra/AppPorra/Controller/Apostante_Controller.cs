using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPorra.Controller 
{
    internal class Apostante_Controller 
    {
        public static void hacerUnaApuesta(List<Model.Apostante> apuestas, String nombre_apostante, int goles_madrid, int goles_bayern)
        {
            Model.Apostante apuesta = new Model.Apostante(nombre_apostante, goles_madrid, goles_bayern);
            apuestas.Add(apuesta);
        }//fin hacerUnaApuesta()
        public static void listar_apuestas(List<Model.Apostante> apostantes)
        {
            int i = 0;
            Console.WriteLine("Numero de apuestas : " + apostantes.Count);
            apostantes.ForEach(apuesta => {
                Console.WriteLine(apuesta.ToString());
            });
        }//fin listar_apuestas()

        //mostrar ganadores y premios
        static int nro_ganadores = 0;
        public static void mostrar_ganadores_premio(List<Model.Apostante> apostantes, int resultado_goles_Md, int resultado_goles_By)
        {
            try
            {

                apostantes.ForEach(apuesta => {
                    if (apuesta.getGoles_madrid() == resultado_goles_Md && apuesta.getGoles_bayern() == resultado_goles_By)
                    {
                        Console.WriteLine(apuesta.ToString() + " || HA GANADO ACERTADO LA APUESTA");
                        nro_ganadores++;
                    }
                });
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR EN EL CALCULO DE PREMIOS {e.Message}");
            }
            finally
            {
                double precio_porra = 9.99;
                double premio = 0;
                premio = apostantes.Count * precio_porra;
                double premio_final = 0;
                premio_final = premio / nro_ganadores;

                if (premio_final == 0)
                {
                    Console.WriteLine("NADIE HA GANADO o HAY NINGUN APOSTANTE");

                }
                else Console.WriteLine("\n$$$$$$$$$$$$ TU premio es de " + Math.Round(premio_final) + " euros $$$$$$$$$$$$$$$$$$$");
            }
        }//fin mostrar_ganadores_premio()
    }
}
