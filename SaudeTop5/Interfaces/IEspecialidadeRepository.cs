using SaudeTop5.Dto.Especialidade;
using SaudeTop5.Entidade;

namespace SaudeTop5.Interfaces
{
    public interface IEspecialidadeRepository
    {
        List<EspecialidadeDto> ListarTodos();
        EspecialidadeDto ListarPorId(int id);
        Especialidade Criar(EspecialidadeCriarDto especialidade);
        Especialidade Editar(EspecialidadeEditarDto especialidade);
        int Excluir(int Id);
    }
}
