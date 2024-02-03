using MiApi.AccesoDatos;
using MiApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MiApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectoController : ControllerBase
    {
        private ManejoProyecto manejoProyecto;
        private ManejoEquipo manejoEquipo;
        public ProyectoController()
        {
            AccesoDato accesoDato = new AccesoDato();
            manejoProyecto = new ManejoProyecto(accesoDato);
            manejoEquipo = new ManejoEquipo(accesoDato);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Proyecto>> GetProyectos()
        {
            try
            {
                return Ok(manejoProyecto.ObtenerProyectos());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Proyecto> ObtenerProyectoPorId(int id)
        {
            try
            {
                var proyecto = manejoProyecto.ObtenerProyectoPorId(id);

                if (proyecto != null)
                    return Ok(proyecto);
                else
                    return NotFound($"Proyecto con ID {id} no encontrado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPost]
        public ActionResult<bool> AgregarProyecto([FromBody] Proyecto nuevoProyecto)
        {
            try
            {
                bool control = manejoProyecto.AgregarProyecto(nuevoProyecto);

                if (control)
                    return Ok(true);
                else
                    return BadRequest("Error al agregar el proyecto");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPost("{id}/tareas")]
        public ActionResult<bool> AgregarTareaAProyecto(int id, [FromBody] Tarea nuevaTarea)
        {
            try
            {
                bool control = manejoProyecto.AgregarTareaAProyecto(id, nuevaTarea.Nombre, nuevaTarea.Descripcion, nuevaTarea.FechaInicio, nuevaTarea.FechaFin);

                if (control)
                    return Ok(true);
                else
                    return NotFound($"Proyecto con ID {id} no encontrado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPost("{idProyecto}/equipos/{idEquipo}")]
        public ActionResult<bool> AgregarEquipoAProyecto(int idProyecto, int idEquipo)
        {
            try
            {
                // Verificar si el proyecto y el equipo existen
                Proyecto proyecto = manejoProyecto.ObtenerProyectoPorId(idProyecto);
                Equipo equipo = manejoEquipo.ObtenerEquipoPorId(idEquipo);

                if (proyecto == null)
                    return NotFound($"Proyecto con ID {idProyecto} no encontrado");

                if (equipo == null)
                    return NotFound($"Equipo con ID {idEquipo} no encontrado");

                // Asignar el equipo al proyecto
                proyecto.Equipo = equipo;
                manejoProyecto.ActualizarProyecto(proyecto);

                return Ok(true);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

    }
}
