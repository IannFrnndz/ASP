using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        var cola = new Queue<string>();
        cola.Enqueue("Mario");
        cola.Enqueue("Iris");
        cola.Enqueue("Amelia");

        while (cola.Count > 0)
        {
            var nombre = cola.Dequeue();
            Console.WriteLine(nombre);
        }
    }
}