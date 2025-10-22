using System;

public class  Persona
{
    public int Edad { get; set; }
    public string? Nombre { get; set; }
}
public class Program
{
    public static void Main(string[] args)
    {
        var personas = new List<Persona>
        {

            new Persona { Nombre = "Ana", Edad = 25 },

            new Persona { Nombre = "Luis", Edad = 30 },

            new Persona { Nombre = "María", Edad = 22 },

            new Persona { Nombre = "Carlos", Edad = 30 }

        };

        Console.WriteLine("EJERCICIO 3");
        Console.WriteLine("1. Ordena por edad de forma ascendente\n");

        var ascendente = personas.OrderBy(p => p.Edad);

        foreach (var persona in ascendente)
        {
            Console.WriteLine($"Nombre: {persona.Nombre}, Edad: {persona.Edad}");
        }

        Console.WriteLine("\n2. Ordena por nombre de forma descendente\n");

        var descendente = personas.OrderBy(p => p.Nombre).ThenByDescending(p => p.Nombre);

        foreach (var persona in descendente)
        {
            Console.WriteLine($"Nombre: {persona.Nombre}, Edad: {persona.Edad}");
        }
        Console.WriteLine("\n3. Ordena por edad descendente y luego por nombre ascendente\n");

        var eDesc = personas.OrderByDescending(p =>p.Edad).ThenBy(p => p.Nombre);

        foreach (var persona in eDesc)
        {
            Console.WriteLine($"Nombre: {persona.Nombre}, Edad: {persona.Edad}");
        }

    }
}