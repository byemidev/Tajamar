
namespace Herencia
{
    internal class Triangulo : Figura
    {
        public Triangulo(double iBase, double iAltura): base (iBase, iAltura) {
             
        }

        public override double calcularArea() {
            base.area = (this.iBase * this.iAltura) / 2;
            return base.area;
        }
    }
}
