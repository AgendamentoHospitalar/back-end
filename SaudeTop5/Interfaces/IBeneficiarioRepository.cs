using SaudeTop5.Entidade;
using SaudeTop5.Dto.Beneficiario;
using SaudeTop5.Entidade;

namespace SaudeTop5.Interfaces
{
    public interface IBeneficiarioRepository
    {
        List<BeneficiarioDto> ListarTodos();
        BeneficiarioDto ListarPorId(int id);
        Beneficiario Criar(BeneficiarioCriarDto beneficiario);
        Beneficiario Editar(BeneficiarioEditarDto beneficiario);
        int Excluir(int Id);
    }
}