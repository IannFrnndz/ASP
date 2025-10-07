using System;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Ingresa un numero: ");
        string? entrada = Console.ReadLine();

        if (int.TryParse(entrada, out int numero))
        {
            Console.WriteLine($"Número: {numero}");
            try
            {
                if (numero < 0)
                    Console.WriteLine($"Error: el número {numero} no puede ser negativo");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Bloque finally siempre ejecutado");
            }
        }
        else
        {
            Console.WriteLine("No es un número válido");
        }
    }
}