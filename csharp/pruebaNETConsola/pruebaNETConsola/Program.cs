// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace pruebaNETConsola {



    internal class programa {
        public static void Main(String[] args) {
            //repaso basico clases
            /*
            person obj_person = new person();

            obj_person.Dni = 41;
            obj_person.Edad = 30;
            obj_person.Nombre = "Emilio";
            obj_person.Apellido1 = "Arevalo";
            obj_person.Apellido2 = "Zuniga";

            Boolean result = obj_person.esMayor();


            Console.WriteLine(obj_person.ToString());

            if (result) {
                Console.WriteLine("Enhorabuena eres mayor de edad puedes ir a la carcel");
            }

            Console.WriteLine("Cual es tu direccion??\n");
            String input = Console.ReadLine();

            Console.WriteLine("\nTu direccion es " + input);
            */

            //output ejercicios

            Console.WriteLine("Elije una de las siguientes opciones");
            Console.WriteLine("1 - EJERCICIO 1 - suma dos numeros");
            Console.WriteLine("2 - EJERCICIO 2 - hallar el area dada base y altura");
            Console.WriteLine("3 - EJERCICIO 3 - factorial de un numero");
            Console.WriteLine("4 - EJERCICIO 4 - Numero primo");
            Console.WriteLine("5 - EJERCICIO 5");
            Console.WriteLine("6 - EJERCICIO 6");
            Console.WriteLine("7 - EJERCICIO 7");
            Console.WriteLine("8 - EJERCICIO 8");
            Console.WriteLine("9 - EJERCICIO 9");


            int opcion = int.Parse(Console.ReadLine());

            switch (opcion) {
                case 1:
                    ejercicio1();
                    break;
                case 2:
                    ejercicio2();
                    break;
                case 3:
                    ejercicio3();
                    break;
                case 4:
                    ejercicio4();
                    break;
                default:
                    Console.WriteLine("no disponible");
                    break;
            }
        }



        //EJERCICIOS

        //ejercicio1
        //Suma de dos números: Pide al usuario que ingrese dos números y muestra la suma de ellos. 
        public static void ejercicio1()
        {

            Console.WriteLine("Escribe el primer numero para la suma:");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Escribe el segundo numero para la suma:");
            double b = double.Parse(Console.ReadLine());

            Console.WriteLine(a+b);
        }

        //ejercicio2 
        //Área de un triángulo: Solicita al usuario que ingrese la base y la altura de un triángulo y calcula su área. 
        public static void ejercicio2()
        {
            Console.WriteLine("Ingresa la base del triangulo:");
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine("Ingresa la altura:");
            double a = double.Parse(Console.ReadLine());

            Console.WriteLine((a*b)/2);
        }

        //ejercicio3
        //Factorial de un número: Pide al usuario que ingrese un número y muestra su factorial. 
        public static void ejercicio3() {
            Console.WriteLine("Escribe un numero para calcular su factorial");
            int num = int.Parse(Console.ReadLine());

            double factorial = 1;
            for (int i = 1; i <= num; i++) {
                factorial *= i;
            }

            Console.WriteLine("El resultado es: \n" + factorial);
        }

        //ejercicio 4
        //Números primos: Solicita al usuario que ingrese un número y determina si es primo o no. 

        public static void ejercicio4() //AQUI TODO: fix method
        {
            Console.WriteLine("Escribe el numero");
            int num = int.Parse(Console.ReadLine());

            Boolean esPrimo = false;

            for (int i = 1; i <= num; i++) {
                if (num % i == 0)
                {
                    esPrimo = true;
                }
                else {
                    esPrimo = false;
                }
            }

            if (esPrimo)
            {
                Console.WriteLine("SI primo");
            }
            else Console.WriteLine("NO es primo");
        }


    }//end class programa









    //para repaso clases y objetos
    public class person()
    {
        
        //definicion de variable
        int dni, edad;

        private String nombre, apellido1, apellido2;

        
        //encapsulamiento simplificado
        public int Dni { get => dni; set => dni = value; }
        public int Edad { get => edad; set => edad = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido1 { get => apellido1; set => apellido1 = value; }
        public string Apellido2 { get => apellido2; set => apellido2 = value; }

        //sobrecarga de metodos .toString()
        public override string ToString()
        {
            return "DNI: " + this.Dni + "\nEDAD: " + this.Edad + "\nNOMBRE: " + this.Nombre + "\nAPELLIDOS: " + this.Apellido1 + " " + this.Apellido2;
        }

        //funciones de clase
        public Boolean esMayor() {
            if (this.Edad >=18) { 
                return true;
            }
            return false;
        } 

    }
}

