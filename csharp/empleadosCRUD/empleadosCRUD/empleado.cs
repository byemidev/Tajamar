using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace empleadosCRUD
{
    internal class empleado
    {
        private int codigo, codigo_departamento;
        private string  nif, nombre, apellido1, apellido2;

        public empleado(string nif, string nombre, string apellido1, string apellido2, int codigo_departamento) { 
            this.nif = nif;
            this.nombre = nombre;
            this.apellido1 = apellido1;
            this.apellido2 = apellido2;
            this.codigo_departamento = codigo_departamento; 
        }

        public string getNif()
        {
            return this.nif;
        }

        public string getNombre()
        {
            return this.nombre;
        }

        public string getApellido1()
        {
            return this.apellido1;
        }

        public string getApellido2()
        {
            return this.apellido2;
        }

        public int getCodigoDep() {
            return this.codigo_departamento;
        }

        public override string ToString() {
            return "codigo: " + this.codigo + "nif: " + this.nif + "nombre: " + this.nombre + "apellido: " + this.apellido1 + "apellido: " + this.apellido2 + "codigo dep" + this.codigo_departamento;
        }
    }
}
