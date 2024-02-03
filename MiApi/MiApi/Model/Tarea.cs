namespace MiApi.Model
{
    public enum Estado
    {
        Pendiente,
        EnProgreso,
        Completada
    }
    public class Tarea
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public Estado EstadoTarea { get; set; }

        public Tarea(int id, string nombre, string descripcion, DateTime fechaInicio, DateTime fechaFin)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            EstadoTarea = Estado.Pendiente; // Estado por defecto
        }
    }
}
