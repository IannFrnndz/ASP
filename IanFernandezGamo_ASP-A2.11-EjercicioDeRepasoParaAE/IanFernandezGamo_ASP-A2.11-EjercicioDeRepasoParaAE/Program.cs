using System;
using System.Collections.Generic;

public abstract class Vehiculo
{
    private string matricula;
    private double consumo;
    public double CostoOperacionalBase => 0.15;

    public string Matricula
    {
        get { return matricula; }
        set { matricula = value; }
    }

    public double Consumo
    {
        get { return consumo; }
        set { consumo = (value < 0) ? 0.0 : value; }
    }

    public Vehiculo(string matricula, double consumo)
    {
        Matricula = matricula;
        Consumo = consumo;
    }

    public abstract double CalcularCostoPorKm();

    public override string ToString()
    {
        return $"Matrícula: {Matricula}, Consumo: {Consumo} L/100km, Costo base: {CostoOperacionalBase}€/L";
    }
}

public class Autobus : Vehiculo
{
    private double capacidadMaxima;
    public double CapacidadMaxima
    {
        get { return capacidadMaxima; }
        set { capacidadMaxima = (value < 0) ? 0.0 : value; }
    }

    public Autobus(string matricula, double consumo, double capacidadMaxima)
        : base(matricula, consumo)
    {
        CapacidadMaxima = capacidadMaxima;
    }

    public override double CalcularCostoPorKm()
    {
        double factorDesgaste = 1.2;
        return Consumo * CostoOperacionalBase * factorDesgaste;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Capacidad máxima: {CapacidadMaxima} pasajeros";
    }
}

public class Camion : Vehiculo
{
    private double peajeAnual;
    public double PeajeAnual
    {
        get { return peajeAnual; }
        set { peajeAnual = (value < 0) ? 0.0 : value; }
    }

    public Camion(string matricula, double consumo, double peajeAnual)
        : base(matricula, consumo)
    {
        PeajeAnual = peajeAnual;
    }

    public override double CalcularCostoPorKm()
    {
        return (Consumo * CostoOperacionalBase) + (PeajeAnual / 100000.0);
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Peaje anual: {PeajeAnual}€";
    }
}

public class Program
{
    public static void Main()
    {
        List<Vehiculo> flota = new List<Vehiculo>();
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("\n=== SISTEMA DE GESTIÓN DE FLOTA FLEETMANAGER S.A. ===");
            Console.WriteLine("1. Registrar Vehículo");
            Console.WriteLine("2. Ver Costos Operacionales");
            Console.WriteLine("3. Calcular Costo Total de Flota (100,000 km por vehículo)");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    RegistrarVehiculo(flota);
                    break;
                case "2":
                    VerCostos(flota);
                    break;
                case "3":
                    CalcularCostoFlota(flota);
                    break;
                case "4":
                    salir = true;
                    Console.WriteLine("Saliendo del sistema...");
                    break;
                default:
                    Console.WriteLine("Opción no válida, intente de nuevo.");
                    break;
            }
        }
    }

    static void RegistrarVehiculo(List<Vehiculo> flota)
    {
        Console.WriteLine("\nSeleccione tipo de vehículo:");
        Console.WriteLine("1. Autobús");
        Console.WriteLine("2. Camión");
        Console.Write("Opción: ");
        int tipo;
        if (!int.TryParse(Console.ReadLine(), out tipo))
        {
            Console.WriteLine("Opción inválida.");
            return;
        }

        Console.Write("Matrícula: ");
        string matricula = Console.ReadLine();

        Console.Write("Consumo (L/100km): ");
        double consumo = LeerDouble();

        if (tipo == 1)
        {
            Console.Write("Capacidad máxima (número de pasajeros): ");
            double capacidad = LeerDouble();
            flota.Add(new Autobus(matricula, consumo, capacidad));
            Console.WriteLine("Autobús registrado correctamente.\n");
        }
        else if (tipo == 2)
        {
            Console.Write("Peaje anual (€): ");
            double peaje = LeerDouble();
            flota.Add(new Camion(matricula, consumo, peaje));
            Console.WriteLine("Camión registrado correctamente.\n");
        }
        else
        {
            Console.WriteLine("Tipo de vehículo no válido.\n");
        }
    }

    static void VerCostos(List<Vehiculo> flota)
    {
        if (flota.Count == 0)
        {
            Console.WriteLine("No hay vehículos registrados.\n");
            return;
        }

        Console.WriteLine("\n=== COSTOS OPERACIONALES ===");
        foreach (var v in flota)
        {
            Console.WriteLine(v.ToString());
            Console.WriteLine($"Costo por km: {v.CalcularCostoPorKm():C4}\n");
        }
    }

    static void CalcularCostoFlota(List<Vehiculo> flota)
    {
        if (flota.Count == 0)
        {
            Console.WriteLine("No hay vehículos registrados.\n");
            return;
        }

        double total = 0.0;
        double distancia = 100000.0;

        foreach (var v in flota)
            total += v.CalcularCostoPorKm() * distancia;

        Console.WriteLine($"\nCosto total estimado de la flota (100,000 km por vehículo): {total:C2}\n");
    }

    static double LeerDouble()
    {
        double valor;
        string entrada = Console.ReadLine()?.Replace(',', '.');
        if (!double.TryParse(entrada, System.Globalization.NumberStyles.Float,
            System.Globalization.CultureInfo.InvariantCulture, out valor))
        {
            Console.WriteLine("Valor inválido. Se asignará 0 por defecto.");
            valor = 0.0;
        }
        return valor;
    }
}
