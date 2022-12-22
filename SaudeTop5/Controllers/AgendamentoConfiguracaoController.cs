using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaudeTop5.Dto.AgendamentoConfiguracao;
using SaudeTop5.Dto.Beneficiario;
using SaudeTop5.Entidade;
using SaudeTop5.Interfaces;
using SaudeTop5.Repositorios;

namespace SaudeTop5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoConfiguracaoController : ControllerBase
    {
        private readonly IAgendamentoConfiguracaoRepository _agendamentoConfigRepository;

        public AgendamentoConfiguracaoController(IAgendamentoConfiguracaoRepository agendamentoConfigRepository)
        {
            _agendamentoConfigRepository = agendamentoConfigRepository;
        }

        [HttpGet]
        [Route("ListarTodos")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AgendamentoConfigDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarTodos()
        {
            try
            {
                List<AgendamentoConfigDto> lista = _agendamentoConfigRepository.ListarTodos();
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AgendamentoConfiguracao))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Criar(AgendamentoConfigCriarDto novoAgendamentoConfig)
        {
            try
            {
                AgendamentoConfiguracao agendametoConfigEntidade = _agendamentoConfigRepository.Criar(novoAgendamentoConfig);

                return Ok(agendametoConfigEntidade);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        [Route("Editar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AgendamentoConfiguracao))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Editar(AgendamentoConfigEditarDto agendamentoConfig)
        {
            try
            {
                AgendamentoConfiguracao agendamentoConfigEntidade = _agendamentoConfigRepository.Editar(agendamentoConfig);

                return Ok(agendamentoConfigEntidade);

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
                int linhasRetornadas = _agendamentoConfigRepository.Excluir(id);
                return Ok(linhasRetornadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
