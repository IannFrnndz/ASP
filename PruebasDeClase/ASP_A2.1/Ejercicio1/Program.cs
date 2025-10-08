using System;

public class Program
{
    public static void Main()
    {
         var numeros  = new List<int> { 1, 2, 3, 4, 5 };

        foreach(var numero in numeros)
        {
            Console.WriteLine(numero);
        }
    }
}