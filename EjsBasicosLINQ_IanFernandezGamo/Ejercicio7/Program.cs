using System;

public class  Program
{
    public static void Main()
    {
        List<string> nombres = new List<string> { "Ana", "Luis", "Marta" };

        var listaAnonima = nombres.Select(n => new {Nombre = n, Longitud = n.Length}).ToList();

        Console.WriteLine("Nombres y sus longitudes:");
        foreach (var item in listaAnonima)
        {
            Console.WriteLine($"Nombre: {item.Nombre}, Longitud: {item.Longitud}");
        }
    }
}