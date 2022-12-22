using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaudeTop5.Dto.Beneficiario;
using SaudeTop5.Dto.Hospital;
using SaudeTop5.Entidade;
using SaudeTop5.Interfaces;
using SaudeTop5.Repositorios;

namespace SaudeTop5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private readonly IHospitalRepository _hospitalRepository;


        public HospitalController(IHospitalRepository hospitalRepository)
        {
            _hospitalRepository = hospitalRepository;
        }

        [HttpGet]
        [Route("ListarTodos")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<HospitalDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult ListarTodos()
        {
            try
            {
                List<HospitalDto> lista = _hospitalRepository.ListarTodos();
                if (lista == null)
                {
                    return NoContent();
                }

                if (lista.Count == 0)
                {
                    throw new Exception("Sem elementos");
                }

                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("Criar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Hospital))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Criar(HospitalCriarDto novoHospital)
        {
            try
            {
                Hospital hospitalEntidade = _hospitalRepository.Criar(novoHospital);

                return Ok(hospitalEntidade);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPatch]
        [Route("Editar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Hospital))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Editar(HospitalEditarDto hospital)
        {
            try
            {
                Hospital hospitalEntidade = _hospitalRepository.Editar(hospital);

                return Ok(hospitalEntidade);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("Excluir/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Excluir(int id)
        {
            try
            {
                int linhasRetornadas = _hospitalRepository.Excluir(id);
                return Ok(linhasRetornadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
