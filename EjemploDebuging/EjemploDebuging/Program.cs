namespace EjemploDebugging
{
    internal class Program
    {

        static void Hola()
        {
            Console.WriteLine("Hola buenas tardes ");
        }
        static void Main(string[] args)
        {

            Console.WriteLine("Hola buenas tardes ");
            Hola();

            string patata = Console.ReadLine();

            int valor = Convert.ToInt32(patata);

            for(int i = 0; i < valor; i++)
            {
                Console.WriteLine($"El valor de i es: {i}");
            }
        }
    }
}