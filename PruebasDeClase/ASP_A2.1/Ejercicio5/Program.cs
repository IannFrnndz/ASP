using System;

public class Program
{
    public static void Main()
    {
        var numeros = new HashSet<int> { 1, 2, 2, 3, 4, 4, 5};
        foreach (var numero in numeros)
        {
            Console.WriteLine(numero);
        }
    }
}