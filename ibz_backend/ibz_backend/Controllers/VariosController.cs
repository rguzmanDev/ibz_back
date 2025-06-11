using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ibz_backend.Data;
using ibz_backend.Models;
namespace ibz_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VariosController : ControllerBase
    {
        private readonly variosData _variosData;

        public VariosController(variosData variosData)
        {
            _variosData = variosData;            
        }

        [HttpGet("genero")]
        public async Task<IActionResult> getGenero()
        {
            List<Genero> getGenero = await _variosData.get_genero();
            return StatusCode(StatusCodes.Status200OK, getGenero);
        }

        [HttpGet("departamento")]
        public async Task<IActionResult> getDepartamento()
        {
            List<Departamento> getDepartamento = await _variosData.get_departamento();
            return StatusCode(StatusCodes.Status200OK, getDepartamento);
        }

        [HttpGet("estado-civil")]
        public async Task<IActionResult> getEstadoCivil()
        {
            List<EstadoCivil> getEstadoCivil = await _variosData.get_estadoCivil();
            return StatusCode(StatusCodes.Status200OK, getEstadoCivil);
        }

        [HttpGet("municipios/{_iddepartamento}")]
        public async Task<IActionResult> get_municipios(int _iddepartamento)
        {
            List<Municipio> getMunicipio = await _variosData.get_municipios(_iddepartamento);
            return StatusCode(StatusCodes.Status200OK, getMunicipio);
        }


    }
}
