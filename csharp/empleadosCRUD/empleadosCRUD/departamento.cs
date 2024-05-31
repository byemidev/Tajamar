using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace empleadosCRUD
{
    internal class Departamento
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public double presupuesto { get; set; }
        public double gastos { get; set; }


        public Departamento() { 
        //constructor vacio
        }   
        public Departamento(string nombre, double presupuesto, double gastos) {
            this.nombre = nombre;   
            this.presupuesto = presupuesto;
            this.gastos = gastos;
        }

        public override string ToString()
        {
            return "codigo: " + this.codigo + "nombre: " + this.nombre + "presupuesto: " + this.presupuesto + "gastos: " + this.gastos; 
        }

        
    }
}
