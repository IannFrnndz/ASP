using System;

public class Program
{
    public static void Main()
    {
        var pila = new Stack<string>();
        pila.Push("A");
        pila.Push("B");
        pila.Push("C");

        while (pila.Count > 0)
        {
            var letra = pila.Pop();
            Console.WriteLine(letra);
        }

    }
}