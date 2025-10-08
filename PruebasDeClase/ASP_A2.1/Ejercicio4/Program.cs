using System;

public class Program
{
    public static void Main()
    {
        var paises = new Dictionary<string, string>
        {
            { "España", "Madrid" },
            { "Francia", "Paris" },
            { "Alemania", "Berlin" }

           
        };
        foreach (var capital in paises.Values)
        {
            Console.WriteLine(capital);
        }
    }
}