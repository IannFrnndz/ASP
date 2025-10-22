class Program
{
    static void Main(string[] args)
    {
        var palabras = new List<string> { "casa", "coche", "árbol", "mesa", "silla" };

        Console.WriteLine("EJERCICIO 2");
        Console.WriteLine("1. Selecciona solo las palabras que tengan más de 4 letras\n");

        var mas4 = from p in palabras where p.Length > 4 select p;

        foreach (var palabra in mas4)
        {
            Console.WriteLine(palabra);
        }
        Console.WriteLine("\n2. Transforma cada palabra a mayúsculas\n");

        var mayus = palabras.Select(p=> p.ToUpper());

        foreach(var palabra in mayus)
        {
            Console.WriteLine(palabra);
        }
        Console.WriteLine("\n3. Crea un nuevo tipo anónimo con la palabra y su longitud\n");

        var anonimo = palabras.Select(p=> new { Palabra = p, Longitud = p.Length });

        foreach(var palabra in anonimo)
        {
            Console.WriteLine($"Palabra: {palabra.Palabra}, Longitud: {palabra.Longitud}");
        }


    }
}