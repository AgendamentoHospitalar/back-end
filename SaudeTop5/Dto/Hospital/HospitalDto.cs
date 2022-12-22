namespace SaudeTop5.Dto.Hospital
{
    public class HospitalDto
    {
        public int IdHospital { get; set; }

        public string Nome { get; set; } = null!;

        public string? Cnpj { get; set; } = null!;

        public string? Endereco { get; set; } = null!;

        public string? Telefone { get; set; }

        public string? Cnes { get; set; } = null!;

        public bool Ativo { get; set; }

    }
}
