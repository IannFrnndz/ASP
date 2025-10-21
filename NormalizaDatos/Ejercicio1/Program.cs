using Ejercicio1;
using System;

public class Program
{
    public static void Main(string[] args)
    {
        // Lista de datos de partidos 
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

        // Listas para guardar los equipos, competiciones y partidos
        List<Equipo> equipos = new List<Equipo>();
        List<Competicion> competiciones = new List<Competicion>();
        List<Partido> partidos = new List<Partido>();

        // Variables para asignar IDs únicos a cada entidad
        int equipoId = 1;
        int competicionId = 1;
        int partidoId = 1;

        // Recorre cada línea de datos para procesar la información
        foreach (var linea in datos)
        {
            // Divide la línea en partes usando el carácter ';'
            string[] partes = linea.Split(';');
            string nombreEquipo1 = partes[0];
            string nombreEquipo2 = partes[1];
            string resultado = partes[2];
            string nombreCompeticion = partes[3];
            DateOnly fecha = DateOnly.Parse(partes[4]);

            // Busca si el primer equipo ya existe en la lista
            Equipo equipo1 = null;
            foreach (var e in equipos)
            {
                if (e.Nombre == nombreEquipo1)
                {
                    equipo1 = e;
                    break;
                }
            }
            // Si no existe, lo crea y lo añade a la lista
            if (equipo1 == null)
            {
                equipo1 = new Equipo { Id = equipoId++, Nombre = nombreEquipo1 };
                equipos.Add(equipo1);
            }

            // Busca si el segundo equipo ya existe en la lista
            Equipo equipo2 = null;
            foreach (var e in equipos)
            {
                if (e.Nombre == nombreEquipo2)
                {
                    equipo2 = e;
                    break;
                }
            }
            // Si no existe, lo crea y lo añade a la lista
            if (equipo2 == null)
            {
                equipo2 = new Equipo { Id = equipoId++, Nombre = nombreEquipo2 };
                equipos.Add(equipo2);
            }

            // Busca si la competición ya existe en la lista
            Competicion competicion = null;
            foreach (var c in competiciones)
            {
                if (c.Nombre == nombreCompeticion)
                {
                    competicion = c;
                    break;
                }
            }
            // Si no existe, la crea y la añade a la lista
            if (competicion == null)
            {
                competicion = new Competicion { Id = competicionId++, Nombre = nombreCompeticion };
                competiciones.Add(competicion);
            }

            // Crea el partido con los datos obtenidos y lo añade a la lista de partidos
            Partido partido = new Partido
            {
                Id = partidoId++,
                Equipo1Id = equipo1.Id,
                Equipo2Id = equipo2.Id,
                CompeticionId = competicion.Id,
                Resultado = resultado,
                Fecha = fecha
            };
            partidos.Add(partido);
        }

        // Muestra la lista de equipos por consola
        Console.WriteLine("Equipos:");
        foreach (var e in equipos)
            Console.WriteLine($"{e.Id}: {e.Nombre}");

        // Muestra la lista de competiciones por consola
        Console.WriteLine("\nCompeticiones:");
        foreach (var c in competiciones)
            Console.WriteLine($"{c.Id}: {c.Nombre}");

        // Muestra la lista de partidos por consola
        Console.WriteLine("\nPartidos:");
        foreach (var p in partidos)
            Console.WriteLine($"{p.Id}. Equipo 1: {p.Equipo1Id} vs Equipo 2: {p.Equipo2Id} , Competicion:{p.CompeticionId} , Resultado:{p.Resultado} , Fecha:{p.Fecha}");

        

    }
}