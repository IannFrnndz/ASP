using System;
using System.Security.Cryptography.X509Certificates;

namespace PruebasEjSimulacro
{

    class Programa
    {

        static List<Figura> figuras = new List<Figura>();

        static int LeerOpcion()
        {
            while(true)
            {

                if (int.TryParse(Console.ReadLine(), out int opcion){
                    if(opcion >= 1 && opcion <= 4)
                    {
                        return opcion;
                    }else{
                        Console.WriteLine("Opción inválida. Intente de nuevo.");
                    }
                
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1. Ver colección de figuras");
                Console.WriteLine("2. Calcular área de una figura");
                Console.WriteLine("3. Calcular perímetro de una figura");
                Console.WriteLine("4. Salir");
                string input = Console.ReadLine();
                    
                else
                {
                    Console.WriteLine("Entrada inválida. Por favor ingrese un número.");
                }
            }

            static void CrearFigura()
            {
                Console.WriteLine("Elija Circulo, Rectangulo o Rombo");

                var figura = Console.ReadLine().ToLower();

                if (figura == "circulo")
                {
                    Console.WriteLine("Radio:");
                    double radio = -1;
                    if(double.TryParse(Console.ReadLine(), out radio))
                    {
                        Circulo circulo = new Circulo();
                        circulo.Radio = radio;
                        figuras.Add(circulo);
                    }
                        
                }
                else if (figura == "rectangulo")
                {
                    Console.WriteLine("Ingrese la base:");
                    double baseRect = double.Parse(Console.ReadLine());
                    Console.WriteLine("Ingrese la altura:");
                    double altura = double.Parse(Console.ReadLine());
                    Rectangulo rectangulo = new Rectangulo { Base = baseRect, Altura = altura };
                    Console.WriteLine(rectangulo.ToString());
                }
                else if (figura == "rombo")
                {
                    Console.WriteLine("Ingrese la diagonal mayor:");
                    double diagonalMayor = double.Parse(Console.ReadLine());
                    Console.WriteLine("Ingrese la diagonal menor:");
                    double diagonalMenor = double.Parse(Console.ReadLine());
                    Console.WriteLine("Ingrese el lado:");
                    double lado = double.Parse(Console.ReadLine());
                    Rombo rombo = new Rombo { DiagonalMayor = diagonalMayor, DiagonalMenor = diagonalMenor, Lado = lado };
                    Console.WriteLine(rombo.ToString());
                }
                else
                {
                    Console.WriteLine("Figura no reconocida.");
                }
            }

                static void VerColeccion()
                {
                    foreach (var item in figuras)
                    {
                        Console.WriteLine(item); 
                    }
                }

                static void Menu()
                {
                    Console.WriteLine("1- Crear Figura");
                    Console.WriteLine("2- Ver Colección");
                    Console.WriteLine("3- Calcular Área");
                }

                public static void Main(string[] args)
                {
                    while (true)
                    {
                        int opcion = LeerOpcion();
                    }

                    switch(opcion)
                    {
                    case 1:
                    CrearFigura();
                    break;
                    case 2:
                    VerColeccion();
                    break;
                    case 3:
                    CalcularArea();
                    break;
                    case 5:
                    break
                    }
                    if (opcion == 5)
                    {
                        break;
            }

        }




        static void CalcularArea()
    {
    }
    static void CalcularPerimetro()
    {
    }


    abstract class Figura
    {
        static void Main(string[] args)
        { }
        public abstract double ClacularArea();
        public abstract double CalcularPerimetro();
    }


    class Circulo : Figura
    {

        private double _radio;
        public double Radio { get => _radio; set => _radio = value <= 0 ? 1 : value; }

        public double Area { get => Math.PI * Math.Pow(Radio, 2); }

        public double Perimetro { get => 2 * Math.PI * Radio; }
        public override double ClacularArea()
        {
            return Area;

        }

        public override double CalcularPerimetro()
        {
            return Perimetro;
        }

        public override string ToString()
        {
            return $"Círculo de radio {Radio}: Área = {Area}, Perímetro = {Perimetro}";
        }


    }

    

    class Rectangulo : Figura
    {
        private double _base;
        public double Base { get => _base; set => _base = value <= 0 ? 1 : value; }
        private double _altura;
        public double Altura { get => _altura; set => _altura = value <= 0 ? 1 : value; }

        public double Area { get => Base * Altura; }

        public double Perimetro { get => 2 * (Base + Altura); }
        public override double ClacularArea()
        {
            return Area;
        }
        public override double CalcularPerimetro()
        {
            return Perimetro;
        }
        public override string ToString()
        {
            return $"Rectángulo de base {Base} y altura {Altura}: Área = {Area}, Perímetro = {Perimetro}";
        }
    }

    class Rombo : Figura
    {
        private double _diagonalMayor;
        public double DiagonalMayor { get => _diagonalMayor; set => _diagonalMayor = value <= 0 ? 1 : value; }
        private double _diagonalMenor;
        public double DiagonalMenor { get => _diagonalMenor; set => _diagonalMenor = value <= 0 ? 1 : value; }
        private double _lado;
        public double Lado { get => _lado; set => _lado = value <= 0 ? 1 : value; }

        public double Area { get => (DiagonalMayor * DiagonalMenor) / 2; }

        public double Perimetro { get => 4 * Lado; }
        public override double ClacularArea()
        {
            return Area;
        }

        public override double CalcularPerimetro()
        {
            return Perimetro;
        }

        public override string ToString()
        {
            return $"Rombo de diagonales {DiagonalMayor}, {DiagonalMenor} y lado {Lado}: Área = {Area}, Perímetro = {Perimetro}";
        }
    }
}