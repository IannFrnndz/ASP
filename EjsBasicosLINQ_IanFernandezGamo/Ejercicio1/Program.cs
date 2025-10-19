using System;

public class Program
{
    public static void Main()
    {
        int[] numeros = { 5, 12, 8, 23, 4, 16, 19, 7, 10, 3 };
        var mayoresDe10 = from numero in numeros where numero > 10 select numero;

        Console.WriteLine("Números mayores de 10:");
        foreach (var p in mayoresDe10)
        {
                       Console.WriteLine(p);
        }
    }
}