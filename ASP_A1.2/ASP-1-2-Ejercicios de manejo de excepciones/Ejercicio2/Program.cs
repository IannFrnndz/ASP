using System;
class Program
{
    public static void Main(string[] args)
    {
        var dic = new Dictionary<string, int>
{
    { "Ana", 25 },
    { "Luis", 30 }
};

        Console.WriteLine("Ingresa el nombre de un alumno: ");
        string nombre = Console.ReadLine();

        if (dic.TryGetValue(nombre, out int edad))
            Console.WriteLine($"Edad: {edad}");
        else
            Console.WriteLine("Alumno no encontrado");
    }
}