namespace SaudeTop5.Dto.Especialidade
{
    public class EspecialidadeDto
    {
        public int IdEspecialidade { get; set; }

        public string Nome { get; set; } = null!;

        public string? Descricao { get; set; }

        public bool Ativo { get; set; }
    }
}
