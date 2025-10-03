using System;
using System.Collections.Generic;


public class Producto
{
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
}


public class ProductoDetallado : Producto
{
    private Dictionary<string, string> caracteristicas = new();

    
    public string this[string clave]
    {
        get => caracteristicas.ContainsKey(clave) ? caracteristicas[clave] : null;
        set => caracteristicas[clave] = value;
    }

    
    private decimal precio;
    public new decimal Precio
    {
        get => precio;
        set => precio = value < 0 ? 0 : value;
    }

    public void Datos()
    {
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"Precio: {Precio:C}");
        Console.WriteLine("Características:");
        foreach (var car in caracteristicas)
        {
            Console.WriteLine($"  {car.Key}: {car.Value}");
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        var prod1 = new ProductoDetallado { Nombre = "Portátil", Precio = 1200 };
        prod1["Peso"] = "2 Kg";
        prod1["Color"] = "Gris";

        var prod2 = new ProductoDetallado { Nombre = "Smartphone", Precio = -500 };
        prod2["Peso"] = "180 g";
        prod2["Color"] = "Negro";
        prod2["Batería"] = "4000 mAh";

        var prod3 = new ProductoDetallado { Nombre = "Monitor", Precio = 300 };
        prod3["Tamaño"] = "27 pulgadas";
        prod3["Resolución"] = "4K";

        prod1.Datos();
        prod2.Datos();
        prod3.Datos();
    }
}