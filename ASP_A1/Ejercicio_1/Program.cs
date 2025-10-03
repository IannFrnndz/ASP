using System;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("CALCULADORA");

        Console.WriteLine("Escriba el primer numero: ");

        double numero1 = double.Parse(Console.ReadLine());

        Console.WriteLine("Escriba el segundo numero: ");

        double numero2 = double.Parse(Console.ReadLine());

        Console.WriteLine("Escriba la operacion a realizar: ");
        MostrarMenu();

        int opcion = int.Parse(Console.ReadLine());


        switch (opcion)
        {
            case 1:
                
                    double resultado = numero1 + numero2;
                    Console.WriteLine("El resultado de la suma es: " + resultado);
                    break;
            case 2:
                    double resultado2 = numero1 - numero2;
                    Console.WriteLine("El resultado de la resta es: " + resultado2);
                    break;
            case 3:
                    double resultado3 = numero1 * numero2;
                    Console.WriteLine("El resultado de la multiplicacion es: " + resultado3);
                    break;
            case 4:
                    if (numero2 != 0)
                    {
                        double resultado4 = numero1 / numero2;
                        Console.WriteLine("El resultado de la division es: " + resultado4);
                    }
                    else
                    {
                        Console.WriteLine("No se puede dividir entre cero");
                    }
                    break;
            case 5:
                    Console.WriteLine("Saliendo...");
                    break;

        }



    }

    public static void MostrarMenu()
    {
        Console.WriteLine("1. Suma");
        Console.WriteLine("2. Resta");
        Console.WriteLine("3. Multiplicacion");
        Console.WriteLine("4. Division");
        Console.WriteLine("5. Salir");
    }
}
