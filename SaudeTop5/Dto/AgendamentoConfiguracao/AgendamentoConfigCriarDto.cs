namespace SaudeTop5.Dto.AgendamentoConfiguracao
{
    public class AgendamentoConfigCriarDto
    {
        public int IdConfiguracao { get; set; }
        public int IdHospital { get; set; }
        public int IdEspecialidade { get; set; }
        public int IdProfissional { get; set; }
        public DateTime DataHoraInicioAtendimento { get; set; }
        public DateTime DataHoraFinalAtendimento { get; set; }
      
    }
}
