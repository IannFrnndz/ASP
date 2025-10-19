using System;

public class Program
{
    public static void Main()
    {
        List<int> lista = new List<int> { 1, 2, 2, 3, 3, 3, 4 };

        var grupos = lista.GroupBy(n => n);
        Console.WriteLine("Números agrupados y su conteo:");
        foreach (var grupo in grupos)
        {
            Console.WriteLine($"Número {grupo.Key} aparece {grupo.Count()} veces");
        }
    }
}