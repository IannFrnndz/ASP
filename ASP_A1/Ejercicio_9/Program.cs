using System;

public class Producto
{
    protected string nombre;
    protected string descripcion;
    protected double precio;

    public Producto(string nombre, string descripcion, double precio)
    {
        this.nombre = nombre;
        this.descripcion = descripcion;
        this.precio = precio;
    }

    public void Datos()
    {
        Console.WriteLine("Datos del producto:");
        Console.WriteLine($"Nombre: {nombre}");
        Console.WriteLine($"Descripcion: {descripcion}");
        Console.WriteLine($"Precio: {precio}");

    }

    public static void Main(string[] args)
    {

        Console.WriteLine("\nProducto 1: ");
        Console.WriteLine("Ingrese el nombre del producto:");
        string nombre1 = Console.ReadLine();
        Console.WriteLine("Ingrese la descripcion del producto:");
        string descripcion1 = Console.ReadLine();
        Console.WriteLine("Ingrese el precio del producto:");
        double precio1 = double.Parse(Console.ReadLine());




        Console.WriteLine("\nProducto 2: ");
        Console.WriteLine("Ingrese el nombre del producto:");
        string nombre2 = Console.ReadLine();
        Console.WriteLine("Ingrese la descripcion del producto:");
        string descripcion2 = Console.ReadLine();
        Console.WriteLine("Ingrese el precio del producto:");
        double precio2 = double.Parse(Console.ReadLine());





        Console.WriteLine("\nProducto 3: ");
        Console.WriteLine("Ingrese el nombre del producto:");
        string nombre3 = Console.ReadLine();
        Console.WriteLine("Ingrese la descripcion del producto:");
        string descripcion3 = Console.ReadLine();
        Console.WriteLine("Ingrese el precio del producto:");
        double precio3 = double.Parse(Console.ReadLine());

        Console.WriteLine("\nProducto 1: ");
        Producto producto1 = new Producto(nombre1, descripcion1, precio1);
        producto1.Datos();

        Console.WriteLine("\nProducto 2: ");
        Producto producto2 = new Producto(nombre2, descripcion2, precio2);
        producto2.Datos();

        Console.WriteLine("\nProducto 3: ");
        Producto producto3 = new Producto(nombre3, descripcion3, precio3);
        producto3.Datos();
    }
}