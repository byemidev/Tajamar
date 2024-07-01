
namespace Herencia
{
    internal class Figura
    {
        public double area { get; set; }
        public double iBase { get; set; }
        public double iAltura { get; set; }

        public Figura(double iBase , double iAltura) { 
            this.iAltura = iAltura;
            this.iBase = iBase; 
        } 
        public virtual double calcularArea() {
            return this.area;
        }

    }
}
