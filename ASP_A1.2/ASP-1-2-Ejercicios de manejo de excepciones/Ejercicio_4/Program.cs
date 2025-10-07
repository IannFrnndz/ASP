using System;
using System.Collections.Generic;

class Program
{
    public static void Main()
    {
        Dictionary<string, int> productos = new Dictionary<string, int>()
        {
            {"Laptop", 1500},
            {"Mouse", 25},
            {"Teclado", 45}
        };

        Console.Write("Ingresa producto: ");
        string producto = Console.ReadLine()?.Trim();

        if (!productos.TryGetValue(producto, out int precio))
        {
            Console.WriteLine("Producto no encontrado");
            return;
        }

        Console.Write("Ingresa la cantidad: ");
        string cantidadTexto = Console.ReadLine();

        if (!int.TryParse(cantidadTexto, out int cantidad))
        {
            Console.WriteLine("Cantidad no válida");
            return;
        }

        try
        {
            if (cantidad < 0)
                throw new Exception("La cantidad no puede ser negativa");

            int total = precio * cantidad;
            Console.WriteLine($"Total: {total}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}