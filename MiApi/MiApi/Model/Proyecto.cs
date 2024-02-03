namespace MiApi.Model
{
    public class Proyecto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Tarea> Tareas { get; } = new List<Tarea>();
        public Equipo Equipo { get; set; }//esta seria una relacion de agregacion

        public Proyecto(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }
        //esta seria una relacion de composicion
        public void AgregarTarea(string nombre, string descripcion, DateTime fechaInicio, DateTime fechaFin)
        {
            int nuevaId = Tareas.Count + 1;
            Tarea nuevaTarea = new Tarea(nuevaId, nombre, descripcion, fechaInicio, fechaFin);
            Tareas.Add(nuevaTarea);
        }
    }
}
