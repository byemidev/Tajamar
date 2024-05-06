using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApp_v_0_2.Model
{
    internal class Cita
    {
        private Paciente paciente = null;
        private DateTime hora_inicio = new DateTime();
        private DateTime hora_fin = new DateTime();

        public void setHora_inicio(int dia, int mes, int anno, int horas, int mins, string am_pm) {
            String inicio_s = dia + "/" + mes + "/" + anno + " " + horas + ":" + mins + ":" + "00 " + am_pm;

            this.hora_inicio = DateTime.Parse(inicio_s, System.Globalization.CultureInfo.InvariantCulture);
        }

        public void setPaciente(Paciente paciente) { 
            this.paciente = paciente;
        }

        public Paciente getPaciente() { 
            return this.paciente;   
        }

        public DateTime getHora_inicio() {
            return hora_inicio;
        }

        public DateTime getHora_fin()
        {
            return hora_inicio.AddHours(.15); // duran 15 mins.
        }
    }
}
