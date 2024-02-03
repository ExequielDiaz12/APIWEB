using MiApi.AccesoDatos;

namespace MiApi.Model
{
    public class ManejoTarea
    {
        private readonly AccesoDato accesoDato;

        public ManejoTarea(AccesoDato accesoDato)
        {
            this.accesoDato = accesoDato;
        }

        public bool AgregarTarea(Tarea tareaNueva)
        {
            List<Tarea> tareas = accesoDato.LeerTareas();
            tareas.Add(tareaNueva);
            tareaNueva.Id = tareas.Count();
            bool control = accesoDato.Guardar(tareas);

            return control;
        }

        public Tarea ObtenerTarea(int idTarea)
        {
            List<Tarea> tareas = accesoDato.LeerTareas();
            Tarea tareaBuscada = tareas.FirstOrDefault(t => t.Id == idTarea);

            return tareaBuscada;
        }

        public bool ActualizarTarea(Tarea tareaModificada)
        {
            List<Tarea> tareas = accesoDato.LeerTareas();
            Tarea tarea = tareas.FirstOrDefault(t => t.Id == tareaModificada.Id);

            if (tarea!=null)
            {
                tarea.Nombre = tareaModificada.Nombre;
                tarea.Descripcion = tareaModificada.Descripcion;
                tarea.FechaInicio = tareaModificada.FechaInicio;
                tarea.FechaFin = tareaModificada.FechaFin;
                tarea.EstadoTarea = tareaModificada.EstadoTarea;

                return accesoDato.Guardar(tareas);
            }
            else
            {
                return false;
            }
        }

        public bool EliminarTarea(int idTarea)
        {
            List<Tarea> tareas = accesoDato.LeerTareas();
            Tarea tarea = tareas.FirstOrDefault(t => t.Id == idTarea);

            if (tarea != null)
            {
                bool control = tareas.Remove(tarea);
                accesoDato.Guardar(tareas);
                return control;
            }
            else
            {
                return false;
            }
        }

        public List<Tarea> GetTareas()
        {
            return accesoDato.LeerTareas();
        }

        public List<Tarea> GetTareasCompletadas()
        {
            List<Tarea> tareas = accesoDato.LeerTareas();
            return tareas.FindAll(t => t.EstadoTarea == Estado.Completada);
        }
    }
}
