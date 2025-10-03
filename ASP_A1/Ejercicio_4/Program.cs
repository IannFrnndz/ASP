using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Escriba un numero: ");
        int numero1 = int.Parse(Console.ReadLine());
        Console.WriteLine("Escriba otro numero: ");
        int numero2 = int.Parse(Console.ReadLine());

        if (numero1 > numero2)
        {
            Console.WriteLine("El numero mayor es: " + numero1);
        }
        else if (numero2 > numero1)
        {
            Console.WriteLine("El numero mayor es: " + numero2);
        }
        else
        {
            Console.WriteLine("Los numeros son iguales");
        }
    }
}