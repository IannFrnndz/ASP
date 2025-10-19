using System;

public class Program
{
    public static void Main()
    {
        int[] numeros = { 5, 12, 8, 23, 4, 16, 19, 7, 10, 3 };
        var ordenados = numeros.OrderByDescending(n => n);

        Console.WriteLine("Numeros ordenados de manera descendiente: ");
        foreach (var p in ordenados)
        {
            Console.WriteLine(p * 2);
        }
    }
}