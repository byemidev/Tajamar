namespace Herencia {
    public class Program { 
        public static void Main(string[] args)
        {
            Triangulo t = new Triangulo(4,2);
            Console.WriteLine(t.calcularArea());

            Rectangulo r = new Rectangulo(7,3);
            Console.WriteLine(r.calcularArea()); 
        }
    }
}