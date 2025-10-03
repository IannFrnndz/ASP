using System;
using System.Collections.Generic;

namespace ListaProductos
{
    
    public class Producto
    {
        public string Nombre { get; set; }
        public double Precio { get; set; }

        public Producto(string nombre, double precio)
        {
            Nombre = nombre;
            Precio = precio;
        }

        public string Presentacion()
        {

            return $"Producto: {Nombre} - Precio: {Precio} €";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            List<Producto> productos = new List<Producto>
            {
                new Producto("Teclado ", 50.00),
                new Producto("Ratón ", 25.50),
                new Producto("Monitor ", 150.00),
                new Producto("Auriculares", 35.75)
            };

            
            Console.WriteLine("PRODUCTOS");
            foreach (var producto in productos)
            {
                Console.WriteLine(producto.Presentacion());
            }

            // Calcular el precio total
            double precioTotal = 0;
            foreach (var producto in productos)
            {
                precioTotal += producto.Precio;
            }

            Console.WriteLine($"\nPrecio total sin descuento: {precioTotal} €");

            
            double descuento = 0.15;
            double precioConDescuento = precioTotal * (1 - descuento);

            Console.WriteLine($"Precio total con 15% de descuento: {precioConDescuento} €");
        }
    }
}
