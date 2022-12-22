using SaudeTop5.Dto.AgendamentoConfiguracao;
using SaudeTop5.Entidade;

namespace SaudeTop5.Interfaces
{
    public interface IAgendamentoConfiguracaoRepository
    {
        List<AgendamentoConfigDto> ListarTodos();
        AgendamentoConfigDto ListarPorId(int id);
        AgendamentoConfiguracao Criar(AgendamentoConfigCriarDto beneficiario);
        AgendamentoConfiguracao Editar(AgendamentoConfigEditarDto beneficiario);
        int Excluir(int Id);
    }
}
