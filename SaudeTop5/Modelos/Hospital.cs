using System;
using System.Collections.Generic;

namespace SaudeTop5.Modelos;

public partial class Hospital
{
    public int IdHospital { get; set; }

    public string Nome { get; set; } = null!;

    public string? Cnpj { get; set; } = null!;

    public string? Endereco { get; set; } = null!;

    public string? Telefone { get; set; }

    public string? Cnes { get; set; } = null!;

    public bool Ativo { get; set; }

    public virtual ICollection<AgendamentoConfiguracao> AgendamentoConfiguracaos { get; } = new List<AgendamentoConfiguracao>();

    public virtual ICollection<Agendamento> Agendamentos { get; } = new List<Agendamento>();
    public int IdHospitais { get; internal set; }
}
