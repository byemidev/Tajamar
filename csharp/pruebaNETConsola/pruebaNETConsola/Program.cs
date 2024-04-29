// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace pruebaNETConsola {



    internal class programa {
        public static void Main(String[] args) {


            menu();




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

        }//final main



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
        }//fin ejercicio1()

        //ejercicio2 
        //Área de un triángulo: Solicita al usuario que ingrese la base y la altura de un triángulo y calcula su área. 
        public static void ejercicio2()
        {
            Console.WriteLine("Ingresa la base del triangulo:");
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine("Ingresa la altura:");
            double a = double.Parse(Console.ReadLine());

            Console.WriteLine((a*b)/2);
        }//fin ejercicio2()

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
        }//fin ejercicio3()

        //ejercicio 4
        //Números primos: Solicita al usuario que ingrese un número y determina si es primo o no. 
        public static void ejercicio4()
        {
            Console.WriteLine("Escribe el numero");
            int num = int.Parse(Console.ReadLine());

            bool esPrimo = false;
            //si es menor que 2 no puede ser primo
            if (num < 2) esPrimo = false;

            if (num % 2 == 0) esPrimo = num == 2; //es divisible por 2
            if (num % 3 == 0) esPrimo = num == 3; //es divisible por 3
            if (num % 5 == 0) esPrimo = num == 5; //es divisible por 5

            double sqrtNum = Math.Sqrt(num); //obtencion de raiz cuadrada
            for (int i = 7; i <= sqrtNum; i += 6) //empezamos el bucle desde el siguiente numero primo a 5, que es 7 e incremento de 6 en 6 i = i + 6
            {
                if (num % i == 0) esPrimo = false; //false si numero es divisible por i
                if (num % (i + 2) == 0) esPrimo = false; //false si es divisible por el el siguiente numeor impar 
            }


            if (esPrimo)
            {
                Console.WriteLine("SI primo");
            }
            else Console.WriteLine("NO es primo");
        }//fin ejercicio4()
        //ejercicio5
        //Conversión de temperatura: Pregunta al usuario si desea convertir de Celsius a Fahrenheit o viceversa
        //y realiza la conversión.
        public static void ejercicio5()
        {
            Console.WriteLine("Introduzca una temperatura que desea convertir");
            double tmp = double.Parse(Console.ReadLine());
            
            Console.WriteLine("\nQuiero convertir de:" 
            + "\n1.-    Celsius (ºC) a Fahreinheit (ºF)"
            + "\n2.-    Fahreinheit (ºF) a Celsius (ºC)"
            + "\n0.-    SALIR."
            );
            
            int opcion = int.Parse(Console.ReadLine());

            if(opcion == 0){
                Environment.Exit(0);
            }

            if(opcion==1){ 
                
                double fahrenheit = (tmp*(9/5)) + 32;
                Console.WriteLine("La temperatura introducida equivale a " + fahrenheit + " ºF." );
            
            }else if(opcion==2){ 
                
                double centigrados = (tmp-32) * (5/9);
                Console.WriteLine("La temperatura introducida equivale a " + centigrados + " ºC.");
            
            }else{
                
                Console.WriteLine("opcion no valida intentalo de nuevo");
                ejercicio5();
            
            }
        }//fin ejercicio5()

        //ejercicio6
        //Cálculo de promedio: Pide al usuario que ingrese una serie de números y calcula su promedio.
        public static void ejercicio6(){
            Console.WriteLine("para esta operacion seran necesario 2 o mas numeros");
            int contador = 0;
            double sumatorio = 0;
            while(true){
                if(contador==0){//se ejecuta una vez para contador == 0
                    Console.WriteLine("Escribe tu primer numero");
                    double num = double.Parse(Console.ReadLine());
                    sumatorio+=num;
                    contador++;
                }
                if(contador==1){//se ejecuta una vez para contador == 1
                    Console.WriteLine("Escribe tu segundo numero");
                    double num = double.Parse(Console.ReadLine());
                    sumatorio+=num;
                    contador++;
                }
                if(contador >= 2){//se ejecuta n veces si contador >= a 2
                    Console.WriteLine("Escribe otro numero o un  '.' para calcular y salir");
                    String cadena = Console.ReadLine();
                    if(cadena=="."){
                        Console.WriteLine("\nGracias. El resultado es: " + sumatorio/contador + " .");
                        break; //para salir del bucle infinito
                    }else{
                    double num = double.Parse(cadena);
                    sumatorio+=num;
                    contador++;
                    }
                }
            }//fin while 
        }//fin ejercicio6()

        //ejercicio7
        //Calculadora básica: Crea una calculadora que pueda sumar, restar, multiplicar y dividir dos números ingresados por el usuario.

        public static void ejercicio7() {
            //para almacenar operaciones aceptadas
            char[] operaciones = {'+', '-', '*', '/'};

            Console.WriteLine("CALCULADORA (escribe X para salir)\n" +
                
                "\nOperaciones: ");
            //mostrando signos de operaciones
            for (int i =  0; i < operaciones.Length; i++) {
                Console.WriteLine(operaciones[i]);
            }


            Console.Write("Escribe el signo de la operacion que deseas realizar:    ");
            string input = Console.ReadLine();
            //instancia char para almacenar operacion
            char operacion = 'x';

            //para evaluar el signo introducido
            bool inputCorrecto = true;

            if (input.Length == 1)
            {
                if (char.TryParse(input, out char operacionInput))
                {
                    inputCorrecto = true;
                    operacion = operacionInput;
                }
                else
                {
                    inputCorrecto = false;
                    Console.WriteLine("operador invalido. Debe pertenecer a los mencionados anteriormente");
                }
            }
            else
            {
                Console.WriteLine("Error: operador debe ser de un un unico caracter");
                inputCorrecto = false;

            }

            //instacias de variables para operar
            double total = 0;
            double nro1 = 0;
            double nro2 = 0;

            if (operacion!='x' && inputCorrecto==true){
                switch (operacion) {
                    case '+':
                        Console.WriteLine("Primer numero para operar:    ");
                        nro1 = double.Parse(Console.ReadLine());

                        Console.WriteLine("segundo numero para operar:    ");
                        nro2 = double.Parse(Console.ReadLine());

                        total = nro1 + nro2;
                        break;
                    case '-':
                        Console.WriteLine("Primer numero para operar:    ");
                        nro1 = double.Parse(Console.ReadLine());

                        Console.WriteLine("segundo numero para operar:    ");
                        nro2 = double.Parse(Console.ReadLine());

                        total = nro1 - nro2;
                        break;
                    case '*':
                        Console.WriteLine("Primer numero para operar:    ");
                        nro1 = double.Parse(Console.ReadLine());

                        Console.WriteLine("segundo numero para operar:    ");
                        nro2 = double.Parse(Console.ReadLine());

                        total = nro1 * nro2;
                        break;
                    case '/':
                        Console.WriteLine("Primer numero para operar:    ");
                        nro1 = double.Parse(Console.ReadLine());

                        Console.WriteLine("segundo numero para operar:    ");
                        nro2 = double.Parse(Console.ReadLine());

                        total = nro1 / nro2;
                        break;
                }
            }

            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            Console.WriteLine("|  " + nro1 + " " + operacion +  " " + nro2 + "  |");
            Console.WriteLine("|                                                                                                 |");
            Console.WriteLine("--------------------------------------------------------------------------------------------------");

            //mostrar resultado
            Console.WriteLine("| Resultado:  " + total);
        }


        //ejercicio 8
        //Generador de números aleatorios: Crea un programa que genere y muestre una serie de números aleatorios. 

        public static void ejercicio8() {

            int limite = 0;
            var obj = new Random();
            
            Console.WriteLine("Introduce el limite para calcular 6 numeros aleatorios");
            try
            {
                double input = double.Parse(Console.ReadLine());
                limite = (int)Math.Round(input);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Error de entrada:   " + e.Message);
            }
            finally {
                for (int i = 0; i < 6; i++)
                {
                    Console.WriteLine(i +"Nro:_____________" + obj.Next(0, limite));   
                }
            }

        }//fin ejercicio8()


        //ejercicio 9
        //Ordenamiento de una lista: Solicita al usuario que ingrese una lista de números y ordénalos de manera ascendente.

        public static void ejercicio9()
        {
            double[] lsNum = { };

            int i = -1;
            do
            {
                try
                {
                    Console.WriteLine("Escribe un numero");
                    lsNum[i++] = double.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine("error" + e.Message);
                    break;
                }
                finally {//ordenando
                    for (int x = 0; x < lsNum.Length; x++) {
                        Console.WriteLine("ordenando....");
                    }
                }
            }while (true);
        }


        //menu

        public static void menu() {
            Console.WriteLine("Elije una de las siguientes opciones");
            Console.WriteLine("0 - Para salir");
            Console.WriteLine("1 - EJERCICIO 1 - Suma dos numeros");
            Console.WriteLine("2 - EJERCICIO 2 - Hallar el area dada base y altura");
            Console.WriteLine("3 - EJERCICIO 3 - factorial de un numero");
            Console.WriteLine("4 - EJERCICIO 4 - Numero primo");
            Console.WriteLine("5 - EJERCICIO 5 - Conversor temperatura");
            Console.WriteLine("6 - EJERCICIO 6 - Hacer media o promedio de");
            Console.WriteLine("7 - EJERCICIO 7 - Calculadora");
            Console.WriteLine("8 - EJERCICIO 8 - Numeros aleatorios");
            Console.WriteLine("9 - EJERCICIO 9");

            int opcion = 0;
            try { 
            opcion = int.Parse(Console.ReadLine());
            }catch(Exception e)
            {
                Console.Error.WriteLine("Error en la entrada de datos" +  e.Message);
                menu();
            }finally {
                switch (opcion)
                {
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
                    case 5:
                        ejercicio5();
                        break;
                    case 6:
                        ejercicio6();
                        break;
                    case 7:
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        ejercicio7();
                        Console.ResetColor();
                        break;
                    case 8:
                        Console.BackgroundColor = ConsoleColor.Red;
                        ejercicio8();
                        Console.ResetColor();
                        break;
                    case 9:
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        ejercicio9();
                        Console.ResetColor();
                        break;
                    case 0:
                        Console.WriteLine("saliendo .....");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("no disponible");
                        menu();
                        break;
                }//fin switch
            }//fin finally
        }//fin menu
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

