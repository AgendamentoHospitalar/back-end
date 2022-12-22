using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaudeTop5.Dto.Especialidade;
using SaudeTop5.Dto.Profissional;
using SaudeTop5.Entidade;
using SaudeTop5.Interfaces;
using SaudeTop5.Repositorios;

namespace SaudeTop5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadeController : ControllerBase
    {
        private readonly IEspecialidadeRepository _especialidadeRepository;

        public EspecialidadeController(IEspecialidadeRepository especialidadeRepository)
        {
            _especialidadeRepository = especialidadeRepository;
        }

        [HttpGet]
        [Route("ListarTodos")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Especialidade>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarTodos()
        {
            try
            {
                List<EspecialidadeDto> lista = _especialidadeRepository.ListarTodos();
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Especialidade))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Criar(EspecialidadeCriarDto novaEspecialidade)
        {
            try
            {
                Especialidade especialidadeEntidade = _especialidadeRepository.Criar(novaEspecialidade);

                return Ok(especialidadeEntidade);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        [Route("Editar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Profissional))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Editar(EspecialidadeEditarDto especialidade)
        {
            try
            {
                Especialidade especialidadeEntidade = _especialidadeRepository.Editar(especialidade);

                return Ok(especialidadeEntidade);

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
                int linhasRetornadas = _especialidadeRepository.Excluir(id);
                return Ok(linhasRetornadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
