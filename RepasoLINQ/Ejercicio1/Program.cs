class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("EJERCICIO 1");
        Console.WriteLine("1. Usando sintaxis de consulta, filtra los números mayores a 5\n");
        var numeros = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        var mayor5 = from n in numeros where n> 5 select n;

        foreach (var numero in mayor5)
        {
            Console.WriteLine(numero);
            
        }

        Console.WriteLine("\n2. Usando sintaxis de método, filtra los números pares\n");
        var pares = numeros.Select(n => n).Where(n => n % 2 == 0);
        foreach (var numero in pares)
        {
            Console.WriteLine(numero);
        }
        Console.WriteLine("\n3. Filtra los números que sean múltiplos de 3\n");

        var multiplos3 = from n in numeros where n % 3 == 0 select n;

        foreach (var numero in multiplos3)
        {
            Console.WriteLine(numero);
        }
    }
}