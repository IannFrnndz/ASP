using System;
using System.Security.Cryptography.X509Certificates;

public abstract class Envio
{
    private string descripcion { get; set; }
    private double peso;

    public double Peso
    {
        get { return peso; }
        set { peso = (value < 0) ? 0.0 : value; }

    }
    public Envio(string descripcion, double peso)
    {
        this.descripcion = descripcion;
        this.peso = peso;
    }

    // propiedad de solo lectura

    public double costoBase => 2.0;

    // metodos polimorficos
    public abstract double CalcularCosto();

    public override string ToString()
    {
        return $"Descripcion: {descripcion}, Peso: {peso} kg, Costo Base: {costoBase}€";
    }

}

public class PaqueteEstandar : Envio
{
    private double tarifaPlana;
    public double TarifaPlana
    {
        get { return tarifaPlana; }
        set { tarifaPlana = (value < 0) ? 0.0 : value; }
    }

    public PaqueteEstandar(string descripcion, double peso, double tarifaPlana):base(descripcion, peso)
    {
        this.tarifaPlana = tarifaPlana;
    }

    public override double CalcularCosto()
    {
        return costoBase  + tarifaPlana;
    }
    public override string ToString()
    {
        return $"{base.ToString()}, Tarifa Plana: {tarifaPlana}€, Costo Total: {CalcularCosto()}€";
    }
}


public class PaqueteExpress : Envio
{
    private double recargoUrgancia;

    public double RecargoUrgencia
    {
        get { return recargoUrgancia; }
        set { RecargoUrgencia = (value < 0) ? 0.0 : value; }

    }

    public PaqueteExpress(string descripcion, double peso, double recargoUrgancia) : base(descripcion, peso)
    {
        this.recargoUrgancia = recargoUrgancia;
    }

    public override double CalcularCosto()
    {
        return costoBase + (recargoUrgancia * Peso);
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Recargo Urgencia: {recargoUrgancia}€/kg, Costo Total: {CalcularCosto()}€";
    }
}

public class Program
{
    public static void Main()
    {
        List<Envio> envios = new List<Envio>();

        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("SISTEMA DE GESTION DE ENVIOS");
            Console.WriteLine("1 Crear envio");
            Console.WriteLine("2 Ver costos individuales");
            Console.WriteLine("3 Calcular ingreso total");
            Console.WriteLine("4 Salir");
            Console.Write("Seleccione una opcion: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {

                case "1":
                    crearEnvio(envios);
                    break;
                case "2":
                    verCostosIndividuales(envios);
                    break;
                case "3":
                    calcularIngresoTotal(envios);
                    break;
                case "4":
                    salir = true;
                    Console.WriteLine("Saliendo de la app");
                    break;
                default:
                    Console.WriteLine("Opcion no valida. Intente de nuevo.");
                    break;
            }

            static void crearEnvio(List<Envio> envios)
            {
                Console.WriteLine("Seleccione tipo de envío:");
                Console.WriteLine("1. Paquete Estándar");
                Console.WriteLine("2. Paquete Express");
                Console.Write("Opción: ");

                int tipo;

                if (!int.TryParse(Console.ReadLine(), out tipo))
                {
                    Console.WriteLine("Tipo inválido.");
                    return;
                }

                Console.Write("Descripción del envío: ");
                string descripcion = Console.ReadLine();

                Console.Write("Peso en kg: ");
                double peso = double.Parse(Console.ReadLine());
                if (tipo == 1)
                {
                    // Paquete Estándar
                    Console.Write("Tarifa plana (opcional, default 10€): ");
                    double tarifa = double.Parse(Console.ReadLine());
                    envios.Add(new PaqueteEstandar(descripcion, peso, tarifa));
                    Console.WriteLine("Paquete Estándar agregado correctamente.");
                }
                else if (tipo == 2)
                {
                    // Paquete Express
                    Console.Write("Recargo por urgencia: ");
                    double recargo = double.Parse(Console.ReadLine());
                    envios.Add(new PaqueteExpress(descripcion, peso, recargo));
                    Console.WriteLine("Paquete Express agregado correctamente.");
                }
                else
                {
                    Console.WriteLine("Tipo de envío no válido.");
                }
            }

            static void verCostosIndividuales(List<Envio> envios)
            {
                if (envios.Count == 0)
                {
                    Console.WriteLine("No hay envíos registrados");
                    return;
                }

                Console.WriteLine("Costos individuales: ");
                foreach (var envio in envios)
                {
                    Console.WriteLine(envio.ToString());
                    Console.WriteLine($"Costo total: {envio.CalcularCosto()} €\n");


                }
            }

            static void calcularIngresoTotal(List<Envio> envios)
            {
                double ingresoTotal = 0.0;
                foreach (var envio in envios)
                {
                    ingresoTotal += envio.CalcularCosto();
                }
                Console.WriteLine($"Ingreso total por envíos: {ingresoTotal}€");
            }
        }
    }
}