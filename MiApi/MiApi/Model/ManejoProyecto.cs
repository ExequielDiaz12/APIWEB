using MiApi.AccesoDatos;

namespace MiApi.Model
{
    public class ManejoProyecto
    {
        private readonly AccesoDato accesoDato;
        private readonly List<Proyecto> proyectos;

        public ManejoProyecto(AccesoDato accesoDato)
        {
            this.accesoDato = accesoDato;
            proyectos = accesoDato.LeerProyectos();
        }
        public bool AgregarProyecto(Proyecto nuevoProyecto)
        {
            if (proyectos.Exists(p => p.Id == nuevoProyecto.Id))
            {
                Console.WriteLine($"Ya existe un proyecto con ID {nuevoProyecto.Id}.");
                return false;
            }

            proyectos.Add(nuevoProyecto);
            GuardarProyectos();
            return true;
        }

        public bool AgregarTareaAProyecto(int idProyecto, string nombre, string descripcion, DateTime fechaInicio, DateTime fechaFin)
        {
            Proyecto proyecto = proyectos.FirstOrDefault(p => p.Id == idProyecto);

            if (proyecto != null)
            {
                proyecto.AgregarTarea(nombre, descripcion, fechaInicio, fechaFin);
                GuardarProyectos();
                return true;
            }
            else
            {
                Console.WriteLine($"Proyecto con ID {idProyecto} no encontrado.");
                return false;
            }
        }

        public List<Proyecto> ObtenerProyectos()
        {
            return proyectos;
        }


        public Proyecto ObtenerProyectoPorId(int idProyecto)
        {
            return proyectos.FirstOrDefault(p => p.Id == idProyecto);
        }

        public bool ActualizarProyecto(Proyecto proyectoModificado)
        {
            Proyecto proyecto = proyectos.FirstOrDefault(p => p.Id == proyectoModificado.Id);

            if (proyecto != null)
            {
                proyecto = proyectoModificado;
                GuardarProyectos();
                return true;
            }
            else
            {
                Console.WriteLine($"Proyecto con ID {proyectoModificado.Id} no encontrado.");
                return false;
            }
        }

        private void GuardarProyectos()
        {
            accesoDato.GuardarProyectos(proyectos);
        }
    }
}
