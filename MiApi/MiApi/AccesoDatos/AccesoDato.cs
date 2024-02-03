using MiApi.Model;
using System.Text.Json;

namespace MiApi.AccesoDatos
{
    public class AccesoDato
    {
        
        private const string TareasFilePath = @"C:\Users\diaza\Desktop\.NET\MiApi\MiApi\Tareas.json";
        private const string ProyectosFilePath = @"C:\Users\diaza\Desktop\.NET\MiApi\MiApi\Proyectos.json";
        private const string EquiposFilePath = @"C:\Users\diaza\Desktop\.NET\MiApi\MiApi\Equipos.json";
        public List<Tarea> LeerTareas()
        {
            try
            {
                if (System.IO.File.Exists(TareasFilePath))
                {
                    var json = System.IO.File.ReadAllText(TareasFilePath);
                    return JsonSerializer.Deserialize<List<Tarea>>(json) ?? new List<Tarea>();
                }

                return new List<Tarea>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer el archivo: {ex.Message}");
                return new List<Tarea>();
            }
        }

        public bool Guardar(List<Tarea> tareas)
        {
            try
            {
                var json = JsonSerializer.Serialize(tareas);
                System.IO.File.WriteAllText(TareasFilePath, json);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al escribir en el archivo: {ex.Message}");
                return false;
            }
        }

        public List<Proyecto> LeerProyectos()
        {
            try
            {
                if (File.Exists(ProyectosFilePath))
                {
                    var json = File.ReadAllText(ProyectosFilePath);
                    return JsonSerializer.Deserialize<List<Proyecto>>(json) ?? new List<Proyecto>();
                }

                return new List<Proyecto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer el archivo de proyectos: {ex.Message}");
                return new List<Proyecto>();
            }
        }

        public async Task<bool> GuardarProyectos(List<Proyecto> proyectos)
        {
            try
            {
                var json = JsonSerializer.Serialize(proyectos);
                await File.WriteAllTextAsync(ProyectosFilePath, json);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al escribir en el archivo de proyectos: {ex.Message}");
                return false;
            }
        }
    
        public List<Equipo> LeerEquipos()
        {
            try
            {
                if (File.Exists(EquiposFilePath))
                {
                    var json = File.ReadAllText(EquiposFilePath);
                    return JsonSerializer.Deserialize<List<Equipo>>(json) ?? new List<Equipo>();
                }
                return new List<Equipo>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer el archivo de equipos: {ex.Message}");
                return new List<Equipo>();
            }
        }

        public async Task<bool> GuardarEquipos(List<Equipo> equipos)
        {
            try
            {
                var json = JsonSerializer.Serialize(equipos);
                await File.WriteAllTextAsync(EquiposFilePath, json);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al escribir en el archivo de equipos: {ex.Message}");
                return false;
            }
        }
    }
}
