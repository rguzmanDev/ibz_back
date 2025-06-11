using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ibz_backend.Data;
using ibz_backend.Models;

namespace ibz_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MiembroController : ControllerBase
    {
        private readonly miembroData _miembroData;
        public MiembroController(miembroData miembroData)
        {
            _miembroData = miembroData;            
        }

        [HttpGet("getListarMiembros")]
        public async Task<IActionResult> getListarMiembros()
        {
            List <Miembros> getListarMiembros = await _miembroData.get_listarMiembros();
            return StatusCode(StatusCodes.Status200OK, getListarMiembros);
        }

        [HttpGet("getMiembro/{_idmiembro}")]
        public async Task<IActionResult> getMiembro(int _idmiembro)
        {
            Miembros getMiembro = await _miembroData.get_miembro(_idmiembro);
            return StatusCode(StatusCodes.Status200OK, getMiembro);
        }

        [HttpPost("createMiembro")]
        public async Task<IActionResult> createMiembro([FromBody] Miembros crearMiembro)
        {
            bool respuesta = await _miembroData.create_miembro(crearMiembro);
            return StatusCode(StatusCodes.Status200OK, new {isSuccess = respuesta});
        }

        [HttpPut("updateMiembro")]
        public async Task<IActionResult> updateMiembro ([FromBody] Miembros actualizarMiembro)
        {
            bool respuesta = await _miembroData.update_miembro(actualizarMiembro);
            return StatusCode(StatusCodes.Status200OK, new { isSuccess = respuesta });
        }

        [HttpDelete("deleteMiembro/{_idmiembro}")]
        public async Task<IActionResult> deleteMiembro(int _idmiembro)
        {
            bool respuesta = await _miembroData.delete_miembro(_idmiembro);
            return StatusCode(StatusCodes.Status200OK, new { isSuccess = respuesta });
        }


    }
}
