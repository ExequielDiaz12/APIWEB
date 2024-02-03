using MiApi.AccesoDatos;

namespace MiApi.Model
{
    public class ManejoEquipo
    {
        private readonly List<Equipo> equipos;
        private readonly AccesoDato accesoDato;
        public ManejoEquipo(AccesoDato accesoDato)
        {
            this.accesoDato = accesoDato;
            equipos = accesoDato.LeerEquipos();
        }

        public bool AgregarEquipo(Equipo nuevoEquipo)
        {
            if (equipos.Exists(e => e.Id == nuevoEquipo.Id))
            {
                Console.WriteLine($"Ya existe un equipo con ID {nuevoEquipo.Id}.");
                return false;
            }

            equipos.Add(nuevoEquipo);
            GuardarEquipos();
            return true;
        }

        public Equipo ObtenerEquipoPorId(int id)
        {
            return equipos.FirstOrDefault(e => e.Id == id);
        }

        public bool ActualizarEquipo(Equipo equipoModificado)
        {
            Equipo equipo = equipos.FirstOrDefault(e => e.Id == equipoModificado.Id);

            if (equipo != null)
            {
                equipo = equipoModificado;
                GuardarEquipos();
                return true;
            }
            else
            {
                Console.WriteLine($"Equipo con ID {equipoModificado.Id} no encontrado.");
                return false;
            }
        }

        public bool EliminarEquipo(int id)
        {
            Equipo equipo = equipos.FirstOrDefault(e => e.Id == id);

            if (equipo != null)
            {
                equipos.Remove(equipo);
                GuardarEquipos();
                return true;
            }
            else
            {
                Console.WriteLine($"Equipo con ID {id} no encontrado.");
                return false;
            }
        }

        public List<Equipo> ObtenerEquipos()
        {
            return equipos;
        }

        private void GuardarEquipos()
        {
            accesoDato.GuardarEquipos(equipos);
        }
    }
}
