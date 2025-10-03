using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Escribe el nombre de un corredor: ");
        string nombre = Console.ReadLine();

        Console.WriteLine("Escribe el tiempo de la primera carrera del corredor en segundos: ");
        double tiempo1 = double.Parse(Console.ReadLine());

        Console.WriteLine("Escribe el tiempo de la segunda carrera del corredor en segundos: ");
        double tiempo2 = double.Parse(Console.ReadLine());

        Console.WriteLine("Escribe el tiempo de la tercera carrera del corredor en segundos: ");
        double tiempo3 = double.Parse(Console.ReadLine());

        CalcularPromedio(nombre,tiempo1,tiempo2,tiempo3);
    }

    public static void CalcularPromedio(string nombre, double tiempo1, double tiempo2, double tiempo3)
    {
        double promedio = (tiempo1 + tiempo2 + tiempo3) / 3;
        Console.WriteLine($"El promedio de tiempos del corredor {nombre} es: {promedio} segundos.");
    }
}