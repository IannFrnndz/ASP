using System;

public class Program
{
    public static void Main()
    {
        List<int> lista = new List<int> { 2, 4, 4, 6, 8, 2, 10 };

        var pares = lista.Where(n => n % 2 == 0);

        var impares = lista.Where(n => n % 2 != 0);
        Console.WriteLine("Cuantos impares hay: " + impares.Count() + " y cuantos pares hay: "+ pares.Count());

    }

}