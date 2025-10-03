using System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Que nota has sacado en el examen?: ");
        int nota = int.Parse(Console.ReadLine());
        if (nota >= 5)
        {
            Console.WriteLine("Has aprobado");
        }
        else
        {
            Console.WriteLine("Has suspendido");
        }
    }
}