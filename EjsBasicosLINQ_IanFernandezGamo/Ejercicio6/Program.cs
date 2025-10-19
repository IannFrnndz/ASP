using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    public static void Main()
    {
        List<int> lista = new List<int> { 1, 2, 2, 3, 3, 3, 4 };

        var mayQueUno = lista.Where(n => n > 1);
        if(mayQueUno.Any())
        {
            var promedio = mayQueUno.Average();
            Console.WriteLine("Promedio mayores que 1: "+ promedio);
        }

    }
}