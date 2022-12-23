using SaudeTop5.Entidade;
using SaudeTop5.Dto.Agendamento;

namespace SaudeTop5.Interfaces
{
    public interface IAgendamentoRepository
    {
        List<AgendamentoDto> ListarTodos();
        AgendamentoDto ListarPorId(int id);
        Agendamento Criar(AgendamentoCriarDto agendamento);
        Agendamento Editar(AgendamentoEditarDto agendamento);
        int Excluir(int Id);
    }
}