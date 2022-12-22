using SaudeTop5.Dto.Profissional;
using Microsoft.AspNetCore.Mvc;
using SaudeTop5.Entidade;
using SaudeTop5.Interfaces;

namespace SaudeTop5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfissionalController : ControllerBase
    {
        
        private readonly IProfissionalRepository _profissionalRepository;

        public ProfissionalController(IProfissionalRepository profissionalRepository)
        {
            _profissionalRepository = profissionalRepository;
        }

        [HttpGet]
        [Route("ListarTodos")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Profissional>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarTodos()
        {
            try
            {
                List<ProfissionalDto> lista = _profissionalRepository.ListarTodos();
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Profissional))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Criar(ProfissionalCriarDto novoProfissional)
        {
            try
            {
                Profissional profissionalEntidade = _profissionalRepository.Criar(novoProfissional);

                return Ok(profissionalEntidade);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //atualizar
        [HttpPatch]
        [Route("Editar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Profissional))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Editar(ProfissionalEditarDto profissional)
        {
            try
            {
                Profissional profissionalEntidade = _profissionalRepository.Editar(profissional);

                return Ok(profissionalEntidade);

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
                int linhasRetornadas = _profissionalRepository.Excluir(id);
                return Ok(linhasRetornadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
