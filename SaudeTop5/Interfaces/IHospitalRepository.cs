using SaudeTop5.Dto.Hospital;
using SaudeTop5.Entidade;

namespace SaudeTop5.Interfaces
{
    public interface IHospitalRepository
    {
        List<HospitalDto> ListarTodos();
        HospitalDto ListarPorId(int id);
        Hospital Criar(HospitalCriarDto hospital);
        Hospital Editar(HospitalEditarDto hospital);
        int Excluir(int Id);
    }
}
