using System;

class Program
{
    public static void Main()
    {
        // ARRAYS

        //Creamos un array de enteros
        int[] numeros = { 4, 8, 1, 6, 3 };

        //Mostramos la longitud del array
        Console.WriteLine($"Longitud: {numeros.Length}");

        //Mostramos los elementos del array
        Array.Sort(numeros);
        Console.WriteLine("Ordenados:");
        
        foreach (var n in numeros)
            Console.Write($"{n} ");

        // Invertimos el array
        Array.Reverse(numeros);
        Console.WriteLine("\nInvertidos:");
        foreach (var n in numeros)
            Console.Write($"{n} ");

        //Buscamos la posición del número 6
        int pos = Array.IndexOf(numeros, 6);
        Console.WriteLine($"\nPosición del número 6: {pos}");

        //Limpiamos el array
        Array.Clear(numeros);
        Console.WriteLine("Después de limpiar:");

        //Mostramos los elementos del array después de limpiarlo 
        foreach (var n in numeros)
            Console.Write($"{n} ");




        // LISTAS

        // creamos una lista de strings
        var frutas = new List<string> { "Pera", "Manzana", "Naranja" };

        // añadimos
        frutas.Add("Plátano");

        //insertamos
        frutas.Insert(1, "Kiwi");

        // eliminamos
        frutas.Remove("Pera");

        // eliminamos el primer elemento
        frutas.RemoveAt(0);

        // mostramos si contiene "Plátano" y el número de elementos
        Console.WriteLine($"¿Contiene 'Plátano'? {frutas.Contains("Plátano")}");
        Console.WriteLine($"Número de frutas: {frutas.Count}");

        // odenamos la lista
        frutas.Sort();

        // mostramos la lista final
        Console.WriteLine("Lista final ordenada:");
        foreach (var f in frutas)
            Console.WriteLine($"- {f}");


        // DICCIONARIOS

        // creamos un diccionario con clave string y valor int
        var edades = new Dictionary<string, int>();
        edades.Add("Ana", 20);
        edades.Add("Luis", 22);
        edades.Add("Marta", 19);

        //Mostramos si existe una clave llamada "Luis" y si existe un valor 20
        Console.WriteLine($"¿Existe la clave 'Luis'?{edades.ContainsKey("Luis")}");
        Console.WriteLine($"¿Existe el valor 20? {edades.ContainsValue(20)}");

        // eliminamos a luis del diccionario
        edades.Remove("Luis");

        // mostramos el total de elementos, las claves y los valores
        Console.WriteLine($"Total de elementos: {edades.Count}");
        Console.WriteLine("Claves:");
        foreach (var clave in edades.Keys)
            Console.WriteLine(clave);
        Console.WriteLine("Valores:");
        foreach (var valor in edades.Values)
            Console.WriteLine(valor);

        // CONJUNTOS
        // creamos dos conjuntos de enteros
        var A = new HashSet<int> { 1, 2, 3, 4 };
        var B = new HashSet<int> { 3, 4, 5, 6 };
        // añadimos y eliminamos elementos
        A.Add(7);
        A.Remove(2);
        // mostramos si contiene el elemento 3
        Console.WriteLine($"¿Contiene 3? {A.Contains(3)}");

        // mostramos la unión, intersección y diferencia entre A y B
        var union = new HashSet<int>(A);
        union.UnionWith(B);
        Console.WriteLine("Unión: " + string.Join(", ", union));
        var inter = new HashSet<int>(A);

        inter.IntersectWith(B);
        Console.WriteLine("Intersección: " + string.Join(", ", inter));
        var diff = new HashSet<int>(A);

        diff.ExceptWith(B);
        Console.WriteLine("Diferencia A - B: " + string.Join(", ", diff));



        // PILAS

        // el último que entra es el primero que sale (FILO)

        // creamos una pila de strings
        var pila = new Stack<string>();
        pila.Push("Inicio");
        pila.Push("Tienda");
        pila.Push("Carrito");

        // Cuando hago peek solo leo el elemento superior sin sacarlo
        // Cuando hago pop leo y saco el elemento superior
        Console.WriteLine($"Elemento superior: {pila.Peek()}"); Console.WriteLine($"Desapilando: {pila.Pop()}");

        // contamos los elementos restantes y los mostramos
        Console.WriteLine($"Total restante: {pila.Count}");
        Console.WriteLine("Elementos restantes:");
        foreach (var e in pila)
            Console.WriteLine(e);


        // COLAS

        // creamos una cola de strings
        var cola = new Queue<string>();
        cola.Enqueue("Cliente1");
        cola.Enqueue("Cliente2");
        cola.Enqueue("Cliente3");

        // Cuando hago peek solo leo el primer elemento sin sacarlo
        Console.WriteLine($"Primero en la cola: {cola.Peek()}");

        // Atendemos al primer cliente (lo sacamos de la cola)
        // contamos cuantos quedan y los mostramos
        Console.WriteLine($"Atendiendo a: {cola.Dequeue()}"); Console.WriteLine($"Clientes restantes:{cola.Count}");
        Console.WriteLine("Cola actual:");
        foreach (var c in cola)
            Console.WriteLine(c);

    }

}