using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPorra.Model
{
    internal class Apostante
    {
        //propiedades de clase
        private String nombre_apostante = "";
        private int goles_madrid = 0;
        private int goles_bayern = 0;

        private String name_madrid = "Real Madrid";
        private String name_bayern = "Bayern Munich";


        //getters
        public String getNombre_apostante()
        {
            return this.nombre_apostante;
        }
        public int getGoles_madrid()
        {
            return this.goles_madrid;
        }
        public int getGoles_bayern()
        {
            return this.goles_bayern;
        }

        public string getNombre_madrid()
        {
            return this.name_madrid;
        }

        public string getNombre_bayern()
        {
            return this.name_bayern;
        }
        //constructor
        public Apostante(String nombre_apostante, int goles_madrid, int goles_bayern)
        {
            this.nombre_apostante = nombre_apostante;
            this.goles_madrid = goles_madrid;
            this.goles_bayern = goles_bayern;
        }

        //sobrecarga .ToString()
        public override string ToString()
        {
            return "Nombre apostante: " + this.getNombre_apostante() + $"\nSu resultado es: {this.getNombre_madrid()}  " + this.getGoles_madrid() + $" vs. {this.getNombre_bayern()}  " + this.getGoles_bayern();
        }
    }
}
