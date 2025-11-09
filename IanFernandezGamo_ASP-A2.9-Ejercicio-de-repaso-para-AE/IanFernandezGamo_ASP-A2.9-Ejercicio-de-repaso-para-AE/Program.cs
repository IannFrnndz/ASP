using System;
using System.Collections.Generic;
public abstract class Empleado
{
    public string nombre {  get; set; }

    public double salarioBase;

    // validamos el salario por si este es negativo

    public double SalarioBase
    {
        get { return salarioBase; }
        set
        {
            if(value < 0)
            {
                salarioBase = 0;
            }
            else
            {
                salarioBase = value;
            }
        }

        // otra forma de hacerlo:
        //get { return salarioBase; }
        //set { salarioBase = (value < 0) ? 0.0 : value; }
    }

    protected Empleado(string nombre, double salarioBase)
    {
        this.nombre = nombre;
        this.salarioBase = salarioBase;
    }

    public abstract double calcularNomina();
    public override string ToString()
    {
        return $"Empleado: {nombre}, salario: {salarioBase}€";
    }
}

public class EmpleadoFijo : Empleado {

    private double bonoAnual;

    // validamos el bono 

    public double BonoAnual
    {
        get { return bonoAnual; }
        set { bonoAnual = (value < 0) ? 0 : value; }
    }
    public EmpleadoFijo(string nombre, double salarioBase,double bonoAnual): base(nombre, salarioBase)
    {
        this.bonoAnual = bonoAnual;
    }

    public override double calcularNomina()
    {
        return salarioBase + bonoAnual / 12;
    }

    public override string ToString()
    {
        return base.ToString() + $", bono anual: {bonoAnual}€";
    }
}


public class EmpleadoPorHora : Empleado
{
    private double tarifaHora;

    public double TarifaHora
    {
        get { return tarifaHora; }
        set { tarifaHora = (value < 0) ? 0 : value; }
    }

    private int horasTrabajasdasMes;

    public int HorasTrabajadasMes
    {
        get { return horasTrabajasdasMes; }
        set { horasTrabajasdasMes = (value < 0) ? 0 : value; }
    }

    public EmpleadoPorHora(string nombre, double salarioBase, double tarifaHora, int horasTrabajadasMes): base(nombre, salarioBase)
    {
        this.tarifaHora = tarifaHora;
        this.horasTrabajasdasMes = horasTrabajadasMes;
    }

    public override double calcularNomina()
    {
        return salarioBase + (tarifaHora * horasTrabajasdasMes);
    }

    public override string ToString()
    {
        return base.ToString() + $", tarifa por hora: {tarifaHora}€, horas trabajadas al mes: {horasTrabajasdasMes}";
    }
}

public class Program
{
    public static void Main()
    {
        List<Empleado> empleados = new List<Empleado>();
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("SISTEMA DE NOMINAS");
            Console.WriteLine("1. Contratar Empleado");
            Console.WriteLine("2 Ver nominas individuales");
            Console.WriteLine("3 Calcular coste total de nóminas");
            Console.WriteLine("4 Salir");
            Console.WriteLine("Selecciona una opcion:");

            string opcion = Console.ReadLine();


            switch (opcion) {
                case "1":
                    contratarEmpleado(empleados);
                    break;
                case "2":
                    mostrarNominas(empleados);
                    break;
                case "3":
                    calcularCosteTotal(empleados);
                    break;
                case "4":
                    salir = true;
                    Console.WriteLine("Saliendo del sistema");
                    break;
                default:
                    Console.WriteLine("Opcion no valida");
                    break;
            }

            static void contratarEmpleado(List<Empleado> empleados)
            {
                Console.WriteLine("ELECCION DE EMPLEADO");
                Console.WriteLine("1 Empleado Fijo");
                Console.WriteLine("2 Empleado Por Hora");
                Console.WriteLine("Seleccione un empleado: ");
                string tipoEmpleado = Console.ReadLine();

                Console.WriteLine("Nombre: ");
                string nombre = Console.ReadLine();

                Console.WriteLine("Salario Base: ");
                double salarioBase = Convert.ToDouble(Console.ReadLine());

                if (tipoEmpleado == "1")
                {
                    Console.WriteLine("Bono Anual: ");
                    double bonoAnual = Convert.ToDouble(Console.ReadLine());

                    empleados.Add(new EmpleadoFijo(nombre, salarioBase, bonoAnual));
                    Console.WriteLine("\nEmpleado fijo agregado correctamente.");
                }
                else if (tipoEmpleado == "2")
                {
                    Console.WriteLine("Tarifa por Hora: ");
                    double tarifaHora = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Horas Trabajadas al Mes: ");
                    int horasTrabajadasMes = Convert.ToInt32(Console.ReadLine());
                    empleados.Add(new EmpleadoPorHora(nombre, salarioBase, tarifaHora, horasTrabajadasMes));
                    Console.WriteLine("\nEmpleado por hora agregado correctamente.");
                }
                else
                {
                    Console.WriteLine("Tipo de empleado no valido");
                }
            }

            static void mostrarNominas(List<Empleado> empleados)
            {

                if (empleados.Count == 0)
                {
                    Console.WriteLine("No hay empleados contratados");
                    return;
                }
                Console.WriteLine("\nNOMINAS INDIVIDUALES");

                foreach (Empleado emp in empleados)
                {
                    Console.WriteLine($"{emp.ToString()}, nomina: {emp.calcularNomina():C2}");
                }
            }

            static void calcularCosteTotal(List<Empleado> empleados)
            {
                if (empleados.Count == 0)
                {
                    Console.WriteLine("No hay empleados contratados");
                    return;
                }
                double costeTotal = 0;
                foreach (Empleado emp in empleados)
                {
                    costeTotal += emp.calcularNomina();
                }
                Console.WriteLine($"\nCoste total de nominas: {costeTotal}€");
            }

            

        }
    }
}