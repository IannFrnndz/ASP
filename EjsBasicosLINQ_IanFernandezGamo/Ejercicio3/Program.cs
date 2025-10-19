using System;

public class Program
{
    public static void Main()
    {
        List<int> lista = new List<int> { 2, 4, 4, 6, 8, 2, 10 };

        var noDuplicados = lista.Distinct();
        Console.WriteLine("Números sin duplicados:");
        Console.WriteLine("Sin duplicados: " + string.Join(", ", noDuplicados));

        Console.WriteLine("Números sin duplicados sumados:");
        Console.WriteLine("Suma : " + noDuplicados.Sum());
    }
}