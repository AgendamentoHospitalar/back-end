namespace SaudeTop5.Dto.Especialidade
{
    public class EspecialidadeEditarDto
    {
        public int IdEspecialidade { get; set; }

        public string Nome { get; set; }

        public string? Descricao { get; set; }

        public bool Ativo { get; set; }
    }
}
