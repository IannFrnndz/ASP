using System;

public class TablaMultiplicar
{
    public int Base { get; set; }



    public int this [int n] { get =>  Base * n; }

}

class Programa
{
    static void Main()
    {
        var tb = new TablaMultiplicar { Base = 5 };
        tb.Base = 5;
        Console.WriteLine($" 5 x 5 = {tb[5]}");

        
    }
}

