using MiApi.AccesoDatos;
using MiApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MiApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipoController : ControllerBase
    {
        private ManejoEquipo manejoEquipo;
        public EquipoController()
        {
            AccesoDato accesoDato = new AccesoDato();
            manejoEquipo = new ManejoEquipo(accesoDato);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Equipo>> ObtenerEquipos()
        {
            try
            {
                var equipos = manejoEquipo.ObtenerEquipos();
                return Ok(equipos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Equipo> ObtenerEquipo(int id)
        {
            try
            {
                var equipo = manejoEquipo.ObtenerEquipoPorId(id);

                if (equipo != null)
                    return Ok(equipo);
                else
                    return NotFound($"Equipo con ID {id} no encontrado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPost]
        public ActionResult<bool> AgregarEquipo([FromBody] Equipo nuevoEquipo)
        {
            try
            {
                bool control = manejoEquipo.AgregarEquipo(nuevoEquipo);

                if (control)
                    return Ok(true);
                else
                    return BadRequest("Error al agregar el equipo");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public ActionResult<bool> ActualizarEquipo(int id, [FromBody] Equipo equipoModificado)
        {
            try
            {
                bool control = manejoEquipo.ActualizarEquipo(equipoModificado);

                if (control)
                    return Ok(true);
                else
                    return NotFound($"Equipo con ID {id} no encontrado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> EliminarEquipo(int id)
        {
            try
            {
                bool control = manejoEquipo.EliminarEquipo(id);

                if (control)
                    return Ok(true);
                else
                    return NotFound($"Equipo con ID {id} no encontrado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
