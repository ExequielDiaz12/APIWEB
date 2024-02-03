using MiApi.AccesoDatos;
using MiApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MiApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private ManejoTarea manejoTarea;
        public TareaController()
        {
            AccesoDato accesoDato = new AccesoDato();
            manejoTarea = new ManejoTarea(accesoDato);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Tarea>> GetTareas()
        {
            try
            {
                return Ok(manejoTarea.GetTareas());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Tarea> ObtenerTarea(int id)
        {
            try
            {
                var tarea = manejoTarea.ObtenerTarea(id);

                if (tarea != null)
                    return Ok(tarea);
                else
                    return NotFound($"Tarea con ID {id} no encontrada");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPost]
        public ActionResult<bool> AgregarTarea([FromBody] Tarea nuevaTarea)
        {
            try
            {
                bool control = manejoTarea.AgregarTarea(nuevaTarea);

                if (control)
                    return Ok(true);
                else
                    return BadRequest("Error al agregar la tarea");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public ActionResult<bool> ActualizarTarea(int id, [FromBody] Tarea tareaModificada)
        {
            try
            {
                tareaModificada.Id = id;
                bool control = manejoTarea.ActualizarTarea(tareaModificada);

                if (control)
                    return Ok(true);
                else
                    return NotFound($"Tarea con ID {id} no encontrada");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> EliminarTarea(int id)
        {
            try
            {
                bool control = manejoTarea.EliminarTarea(id);

                if (control)
                    return Ok(true);
                else
                    return NotFound($"Tarea con ID {id} no encontrada");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("completadas")]
        public ActionResult<IEnumerable<Tarea>> GetTareasCompletadas()
        {
            try
            {
                return Ok(manejoTarea.GetTareasCompletadas());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
