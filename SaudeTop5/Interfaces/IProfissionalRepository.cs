using SaudeTop5.Dto.Profissional;
using SaudeTop5.Entidade;

namespace SaudeTop5.Interfaces
{
    public interface IProfissionalRepository
    {
        List<ProfissionalDto> ListarTodos();
        ProfissionalDto ListarPorId(int id);
        Profissional Criar(ProfissionalCriarDto profissional);
        Profissional Editar(ProfissionalEditarDto profissional);
        int Excluir(int Id);
    }
}
