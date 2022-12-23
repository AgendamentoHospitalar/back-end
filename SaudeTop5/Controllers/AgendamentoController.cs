
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaudeTop5.Dto.Agendamento;
using SaudeTop5.Entidade;
using SaudeTop5.Interfaces;
using SaudeTop5.Repositorios;

namespace SaudeTop5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        private readonly IAgendamentoRepository _agendamentoRepository;

        public AgendamentoController(IAgendamentoRepository agendamentoRepository)
        {
            _agendamentoRepository = agendamentoRepository;
        }


        [HttpGet]
        [Route("ListarTodos")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Agendamento>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarTodos()
        {
            try
            {
                List<AgendamentoDto> lista = _agendamentoRepository.ListarTodos();
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Agendamento))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Criar(AgendamentoCriarDto novoAgendamento)
        {
            try
            {
                Agendamento agendamentoEntidade = _agendamentoRepository.Criar(novoAgendamento);

                return Ok(agendamentoEntidade);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        [Route("Editar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Agendamento))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Editar(AgendamentoEditarDto agendamento)
        {
            try
            {
                Agendamento agendamentoEntidade = _agendamentoRepository.Editar(agendamento);

                return Ok(agendamentoEntidade);

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
                int linhasRetornadas = _agendamentoRepository.Excluir(id);
                return Ok(linhasRetornadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

