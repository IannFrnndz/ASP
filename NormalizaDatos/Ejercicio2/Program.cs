using Ejercicio2;
using System;

public class Program
{
    public static void Main(string[] args)
    {
        // Lista de datos de partidos, cada elemento contiene información separada por ';'
        List<string> datos = new List<string> {
                "Real Madrid;Barcelona;2-1;Liga;2025-10-12",
                "Atlético de Madrid;Sevilla;1-0;Liga;2025-10-13",
                "Barcelona;Valencia;3-2;Copa del Rey;2025-10-14",
                "Sevilla;Real Madrid;0-2;Liga;2025-10-15",
                "Valencia;Atlético de Madrid;1-1;Copa del Rey;2025-10-16",
                "Real Madrid;Atlético de Madrid;2-2;Liga;2025-10-17",
                "Barcelona;Sevilla;4-0;Liga;2025-10-18",
                "Valencia;Real Madrid;0-1;Copa del Rey;2025-10-19",
                "Atlético de Madrid;Barcelona;1-3;Liga;2025-10-20",
                "Sevilla;Valencia;2-2;Copa del Rey;2025-10-21"
         };

        // Obtiene la lista de equipos únicos
        // Toma el nombre de los dos equipos de cada partido, los junta y elimina duplicados
        List<Equipo> equipos = datos
            .SelectMany(d => new[] { d.Split(';')[0], d.Split(';')[1] }) 
            .Distinct() 
            .Select((nombre, index) => new Equipo { Id = index + 1, Nombre = nombre }) 
            .ToList();

        // Obtiene la lista de competiciones únicas
        // Toma el nombre de la competición de cada partido y elimina duplicados
        List<Competicion> competiciones = datos
            .Select(d => d.Split(';')[3]) 
            .Distinct() 
            .Select((nombre, index) => new Competicion { Id = index + 1, Nombre = nombre }) 
            .ToList();

        // Crea la lista de partidos
        // Para cada partido, busca los IDs de los equipos y la competición, y guarda el resultado y la fecha
        List<Partido> partidos = datos
            .Select((linea, index) => {
                string[] partes = linea.Split(';');
                string nombreEquipo1 = partes[0];
                string nombreEquipo2 = partes[1];
                string resultado = partes[2];
                string nombreCompeticion = partes[3];
                DateOnly fecha = DateOnly.Parse(partes[4]);

                int equipo1Id = equipos.First(e => e.Nombre == nombreEquipo1).Id;
                int equipo2Id = equipos.First(e => e.Nombre == nombreEquipo2).Id;
                int competicionId = competiciones.First(c => c.Nombre == nombreCompeticion).Id;

                return new Partido
                {
                    Id = index + 1,
                    Equipo1Id = equipo1Id,
                    Equipo2Id = equipo2Id,
                    CompeticionId = competicionId,
                    Resultado = resultado,
                    Fecha = fecha
                };
            })
            .ToList();

        // Muestra la lista de equipos por consola
        Console.WriteLine("Equipos:");
        equipos.ForEach(e => Console.WriteLine($"{e.Id}: {e.Nombre}"));

        // Muestra la lista de competiciones por consola
        Console.WriteLine("\nCompeticiones:");
        competiciones.ForEach(c => Console.WriteLine($"{c.Id}: {c.Nombre}"));

        // Muestra la lista de partidos por consola
        Console.WriteLine("\nPartidos:");
        partidos.ForEach(p =>
            Console.WriteLine($"{p.Id}. Equipo 1: {p.Equipo1Id} vs Equipo 2: {p.Equipo2Id} , Competicion:{p.CompeticionId} , Resultado:{p.Resultado} , Fecha:{p.Fecha}")
        );
    }
}