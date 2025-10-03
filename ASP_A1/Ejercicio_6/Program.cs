using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Escriba un numero: ");
        int numero = int.Parse(Console.ReadLine());

        if (numero % 2 == 0)
        {
            Console.WriteLine("El numero es par");
        }
        else
        {
            Console.WriteLine("El numero es impar");

        }
    }
}