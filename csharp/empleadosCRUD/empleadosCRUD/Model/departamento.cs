using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace empleadosCRUD.Model
{
    internal class departamento
    {
        private int codigo;
        private string nombre;
        private double presupuesto, gastos;

        public departamento(int codigo, string nombre, double presupuesto, double gastos) {
            this.codigo = codigo;
            this.nombre = nombre;   
            this.presupuesto = presupuesto;
            this.gastos = gastos;
        }

        public override string ToString()
        {
            return ""; 
        }
    }
}
