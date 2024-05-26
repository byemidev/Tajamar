using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApp_v_0_2.Model
{
    internal class Hospital 
    {
        public static Cita alta_cita() 
        {
            //datos paciente
            Console.WriteLine("Escribe el ID del paciente: ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Escribe el Nombre completo del paciente: ");
            string nombre_completo = Console.ReadLine();

            //instancia de paciente

            Paciente paciente = new Paciente(id, nombre_completo);

            //pedir datos para dia y hora 

            Console.WriteLine("Que dia?: ");
            int dia = int.Parse(Console.ReadLine());

            Console.WriteLine("Que mes?: ");
            int mes = int.Parse(Console.ReadLine());    

            Console.WriteLine("Año ? : ");
            int anno = int.Parse(Console.ReadLine());

            Console.WriteLine("Por la mañana 1.- (AM)  \n2.- Por la tarde(PM)");
            int opcion = 0;
            string opcion_string = "";

            if (opcion == 0)
            {
                opcion = int.Parse(Console.ReadLine());
                if (opcion == 1)
                {
                    opcion_string = "AM";
                }else
                {
                    opcion_string = "PM";
                }
            }

            Console.WriteLine("Introduce la hora (formato hh ej. '02')");
            int hora = int.Parse(Console.ReadLine());   

            Console.WriteLine("Introduce los minutos: " +
                "\n1.-  hh:00" + 
                "\n2.-  hh:15" +
                "\n3.-  hh:30" +
                "\n4.-  hh:45");
            int opcion_mins = int.Parse(Console.ReadLine());
            int mins = 0;
            switch (opcion_mins) {
                case 1:
                    mins = 00;
                    break;

                case 2:
                    mins = 15;
                    break;
                case 3:
                    mins = 30;
                    break;
                case 4:
                    mins = 45;
                    break;
                default:
                    mins = 00;
                    break;
            }

            //instancia de cita 

            Cita  cita_obj = new Cita();

            //add datos cita a cita_obj
            //add insatncia de paciente a cita_obj , devolcer cita
            cita_obj.setHora_inicio(dia, mes, anno, hora, mins, opcion_string);
            cita_obj.setPaciente(paciente);

            return cita_obj;
        }
        //BUSCAR PACIENTE CON CITA
        public static Paciente buscar_paciente(List<Cita> citas, int dni_paciente) {

            Paciente paciente_aux = new Paciente();

            citas.ForEach(cita => {
                Paciente paciente = cita.getPaciente();
                if (paciente!=null) {
                    int id_cita = paciente.getDNI_paciente();
                    if ( id_cita == dni_paciente) {
                        paciente_aux = paciente;
                    }
                }
            });

            if(paciente_aux != null){ //para funciones anonimas , no retornan valores
                return paciente_aux;
            }

            return null;
        }

    }
}
