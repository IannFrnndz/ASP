using System;

public class Program
{
    public static void Main(string[] args)
    {
        var palabras = new List<string> { "A", "B", "C", "D", "E" };

        
            Console.Write("Ingresa índice: ");
            string entrada = Console.ReadLine();

            if (int.TryParse(entrada, out int indice))
            {
                var palabra = palabras.ElementAtOrDefault(indice);
                if (palabra != null)
                    Console.WriteLine($"Palabra: \"{palabra}\"");
                else
                    Console.WriteLine("Índice fuera de rango");
            }
            else
            {
                Console.WriteLine("Índice no válido");
            }
        
    }
}