using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herencia
{
    internal class Rectangulo: Figura
    {
        public Rectangulo(double iBase, double iAltura) : base(iBase, iAltura)  
        {
            
        }

        public override double calcularArea()
        {
            base.area = (this.iBase * this.iAltura);
            return base.area;
        }

    }
}
