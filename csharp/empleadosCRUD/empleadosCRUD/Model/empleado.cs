using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace empleadosCRUD.Model
{
    internal class empleado
    {
        private int codigo, codigo_departamento;
        private string  nif, nombre, apellido1, apellido2;

        public empleado(int codigo, string nif, string nombre, string apellido1, string apellido2, int codigo_departamento) { 
            this.codigo = codigo;
            this.nif = nif;
            this.nombre = nombre;
            this.apellido1 = apellido1;
            this.apellido2 = apellido2;
            this.codigo_departamento = codigo_departamento; 
        }

        public  override string ToString() {
            return "codigo: " + this.codigo + "nif: " + this.nif + "nombre: " + this.nombre + "apellido: " + this.apellido1 + "apellido: " + this.apellido2 + "codigo dep" + this.codigo_departamento;
        }
    }
}
