using Ejercicio3;
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

        // Obtiene la lista de equipos únicos usando LINQ
        // Toma el nombre de los dos equipos de cada partido, los junta y elimina duplicados
        var equiposQuery =
            (from d in datos
             from nombre in new[] { d.Split(';')[0], d.Split(';')[1] }
             select nombre)
            .Distinct()
            .Select((nombre, index) => new Equipo { Id = index + 1, Nombre = nombre })
            .ToList();

        // Obtiene la lista de competiciones únicas usando LINQ
        // Toma el nombre de la competición de cada partido y elimina duplicados
        var competicionesQuery =
            (from d in datos
             select d.Split(';')[3])
            .Distinct()
            .Select((nombre, index) => new Competicion { Id = index + 1, Nombre = nombre })
            .ToList();

        // Crea la lista de partidos usando LINQ
        // Para cada partido, busca los IDs de los equipos y la competición, y guarda el resultado y la fecha
        var partidosQuery =
            (from linea in datos.Select((valor, indice) => new { valor, indice })
             let partes = linea.valor.Split(';')
             let nombreEquipo1 = partes[0]
             let nombreEquipo2 = partes[1]
             let resultado = partes[2]
             let nombreCompeticion = partes[3]
             let fecha = DateOnly.Parse(partes[4])
             let equipo1Id = equiposQuery.First(e => e.Nombre == nombreEquipo1).Id
             let equipo2Id = equiposQuery.First(e => e.Nombre == nombreEquipo2).Id
             let competicionId = competicionesQuery.First(c => c.Nombre == nombreCompeticion).Id
             select new Partido
             {
                 Id = linea.indice + 1,
                 Equipo1Id = equipo1Id,
                 Equipo2Id = equipo2Id,
                 CompeticionId = competicionId,
                 Resultado = resultado,
                 Fecha = fecha
             })
            .ToList();

        // Muestra la lista de equipos por consola
        Console.WriteLine("Equipos:");
        equiposQuery.ForEach(e => Console.WriteLine($"{e.Id}: {e.Nombre}"));

        // Muestra la lista de competiciones por consola
        Console.WriteLine("\nCompeticiones:");
        competicionesQuery.ForEach(c => Console.WriteLine($"{c.Id}: {c.Nombre}"));

        // Muestra la lista de partidos por consola
        Console.WriteLine("\nPartidos:");
        partidosQuery.ForEach(p =>
            Console.WriteLine($"{p.Id}. Equipo 1: {p.Equipo1Id} vs Equipo 2: {p.Equipo2Id} , Competicion:{p.CompeticionId} , Resultado:{p.Resultado} , Fecha:{p.Fecha}")
        );
    }
}