using Microsoft.AspNetCore.Mvc;
using SaudeTop5.Dto.Beneficiario;
using SaudeTop5.Dto.Profissional;
using SaudeTop5.Entidade;
using SaudeTop5.Interfaces;
using SaudeTop5.Repositorios;

namespace SaudeTop5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeneficiarioController : Controller
    {
        private readonly IBeneficiarioRepository _beneficiarioRepository;


        public BeneficiarioController(IBeneficiarioRepository beneficiarioRepository)
        {
            _beneficiarioRepository = beneficiarioRepository;
        }

        [HttpGet]
        [Route("ListarTodos")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<BeneficiarioDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarTodos()
        {
            try
            {
                List<BeneficiarioDto> lista = _beneficiarioRepository.ListarTodos();
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Beneficiario))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Criar(BeneficiarioCriarDto novoBeneficiario)
        {
            try
            {
                Beneficiario beneficiarioEntidade = _beneficiarioRepository.Criar(novoBeneficiario);

                return Ok(beneficiarioEntidade);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        [Route("Editar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Beneficiario))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Editar(BeneficiarioEditarDto beneficiario)
        {
            try
            {
                Beneficiario beneficiarioEntidade = _beneficiarioRepository.Editar(beneficiario);

                return Ok(beneficiarioEntidade);

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
                int linhasRetornadas = _beneficiarioRepository.Excluir(id);
                return Ok(linhasRetornadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
