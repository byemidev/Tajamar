using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApp_v_0_2.Model
{
    internal class Paciente
    {
        private string nombre_completo = "";
        private int dni_paciente = 0;

        public int getDNI_paciente()
        {
            return this.dni_paciente;
        }

        //sobrecarga ToString()

        public override string ToString() {
            return $"DNI: {this.dni_paciente}\n NOMBRE COMPLETO: {this.nombre_completo}";            
        }

        //Constructor para program
        public  Paciente(int dni_paciente, string nombre_completo) { 
            this.dni_paciente = dni_paciente; 
            this.nombre_completo = nombre_completo;
        }
        
        public  Paciente()
        { 
            //constructor vacio
        }
    }
}
