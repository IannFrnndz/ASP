using System;
using System.Collections.Generic;

namespace GeoPlannerSA
{
    // Clase base abstracta: define la estructura común de todas las figuras
    abstract class Figura
    {
        public string Tipo => GetType().Name;       // Nombre de la figura (solo lectura)
        public double Area => CalcularArea();       // Propiedad de solo lectura
        public double Perimetro => CalcularPerimetro();

        // Métodos abstractos que obligan a las subclases a implementar sus fórmulas
        protected abstract double CalcularArea();
        protected abstract double CalcularPerimetro();

        // Método virtual que las subclases pueden modificar
        public virtual string Descripcion() => $"{Tipo} - Área: {Area:F2}, Perímetro: {Perimetro:F2}";
    }

    // Círculo
    class Circulo : Figura
    {
        private double _radio;
        public double Radio
        {
            get => _radio;
            set => _radio = (value <= 0) ? 1.0 : value; // Validación
        }

        public Circulo(double radio) => Radio = radio;
        protected override double CalcularArea() => Math.PI * Radio * Radio;
        protected override double CalcularPerimetro() => 2 * Math.PI * Radio;
        public override string Descripcion() => $"{Tipo} (r={Radio:F2}) - Área: {Area:F2}, Perímetro: {Perimetro:F2}";
    }

    // Rectángulo
    class Rectangulo : Figura
    {
        private double _base, _altura;
        public double Base { get => _base; set => _base = (value <= 0) ? 1.0 : value; }
        public double Altura { get => _altura; set => _altura = (value <= 0) ? 1.0 : value; }

        public Rectangulo(double b, double h) { Base = b; Altura = h; }
        protected override double CalcularArea() => Base * Altura;
        protected override double CalcularPerimetro() => 2 * (Base + Altura);
        public override string Descripcion() => $"{Tipo} (b={Base:F2}, h={Altura:F2}) - Área: {Area:F2}, Perímetro: {Perimetro:F2}";
    }

    // Rombo
    class Rombo : Figura
    {
        private double _dMayor, _dMenor;
        public double DiagonalMayor { get => _dMayor; set => _dMayor = (value <= 0) ? 1.0 : value; }
        public double DiagonalMenor { get => _dMenor; set => _dMenor = (value <= 0) ? 1.0 : value; }

        public Rombo(double D, double d) { DiagonalMayor = D; DiagonalMenor = d; }
        protected override double CalcularArea() => (DiagonalMayor * DiagonalMenor) / 2;
        protected override double CalcularPerimetro()
        {
            double lado = Math.Sqrt(Math.Pow(DiagonalMayor / 2, 2) + Math.Pow(DiagonalMenor / 2, 2));
            return 4 * lado;
        }
        public override string Descripcion() => $"{Tipo} (D={DiagonalMayor:F2}, d={DiagonalMenor:F2}) - Área: {Area:F2}, Perímetro: {Perimetro:F2}";
    }

    class Program
    {
        static List<Figura> figuras = new();

        static void Main()
        {
            string opcion;
            do
            {
                MostrarMenu();
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1": CrearFigura(); break;
                    case "2": VerFiguras(); break;
                    case "3": Console.WriteLine($"Área total: {Suma(f => f.Area):F2}\n"); break;
                    case "4": Console.WriteLine($"Perímetro total: {Suma(f => f.Perimetro):F2}\n"); break;
                    case "5": Console.WriteLine("Fin del programa."); break;
                    default: Console.WriteLine("Opción no válida.\n"); break;
                }

            } while (opcion != "5");
        }

        static void MostrarMenu()
        {
            Console.WriteLine("=== GeoPlanner S.A. ===");
            Console.WriteLine("1. Crear figura");
            Console.WriteLine("2. Ver colección");
            Console.WriteLine("3. Calcular área total");
            Console.WriteLine("4. Calcular perímetro total");
            Console.WriteLine("5. Terminar\n");
            Console.Write("Opción: ");
        }

        static void CrearFigura()
        {
            Console.Write("Tipo (c=Circulo, r=Rectangulo, o=Rombo): ");
            string tipo = Console.ReadLine().ToLower();

            try
            {
                switch (tipo)
                {
                    case "c":
                        Console.Write("Radio: ");
                        figuras.Add(new Circulo(double.Parse(Console.ReadLine())));
                        break;
                    case "r":
                        Console.Write("Base: ");
                        double b = double.Parse(Console.ReadLine());
                        Console.Write("Altura: ");
                        double h = double.Parse(Console.ReadLine());
                        figuras.Add(new Rectangulo(b, h));
                        break;
                    case "o":
                        Console.Write("Diagonal mayor: ");
                        double D = double.Parse(Console.ReadLine());
                        Console.Write("Diagonal menor: ");
                        double d = double.Parse(Console.ReadLine());
                        figuras.Add(new Rombo(D, d));
                        break;
                    default:
                        Console.WriteLine("Tipo no válido.\n");
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Error: entrada inválida.\n");
            }
        }

        static void VerFiguras()
        {
            if (figuras.Count == 0) { Console.WriteLine("No hay figuras.\n"); return; }
            for (int i = 0; i < figuras.Count; i++)
                Console.WriteLine($"{i + 1}. {figuras[i].Descripcion()}");
            Console.WriteLine();
        }

        static double Suma(Func<Figura, double> selector)
        {
            double total = 0;
            foreach (var f in figuras) total += selector(f);
            return total;
        }
    }
}