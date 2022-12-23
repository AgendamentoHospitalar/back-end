using SaudeTop5.Context;
using SaudeTop5.Dto.Agendamento;
using SaudeTop5.Entidade;
using SaudeTop5.Interfaces;

namespace SaudeTop5.Repositorios
{
    public class AgendamentoRepository : IAgendamentoRepository
    {
        private readonly DatabaseContext _context;
        public AgendamentoRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Agendamento Criar(AgendamentoCriarDto agendamento)
        {
            Agendamento agendamentoEntidade = new Agendamento()
            {
                IdAgendamento = agendamento.IdAgendamento,
                IdHospital = agendamento.IdHospital,
                IdEspecialidade = agendamento.IdEspecialidade,
                IdProfissional = agendamento.IdProfissional,
                IdBeneficiario = agendamento.IdBeneficiario,
                DataHoraAgendamento = agendamento.DataHoraAgendamento,
                Ativo = agendamento.Ativo,

            };

            _context.ChangeTracker.Clear();
            _context.Agendamentos.Add(agendamentoEntidade);
            _context.SaveChanges();
            return agendamentoEntidade;
        }
        public int Excluir(int Id)
        {
            var agendamento = new Agendamento()
            {
                IdAgendamento = Id
            };

            _context.Agendamentos.Remove(agendamento);
            return _context.SaveChanges();
        }

        public AgendamentoDto ListarPorId(int id)
        {
            return (from t in _context.Agendamentos
                    where t.IdAgendamento == id
                    select new AgendamentoDto()
                    {
                        IdAgendamento = t.IdAgendamento,
                        IdHospital = t.IdHospital,
                        IdEspecialidade = t.IdEspecialidade,
                        IdBeneficiario = t.IdBeneficiario,
                        DataHoraAgendamento = t.DataHoraAgendamento,
                        Ativo = t.Ativo,

                    })
                    ?.FirstOrDefault()
                    ?? new AgendamentoDto();
        }

        public List<AgendamentoDto> ListarTodos()
        {
            return _context.Agendamentos.Select(s => new AgendamentoDto()
            {
                IdAgendamento = s.IdAgendamento,
                IdHospital = s.IdHospital,
                IdEspecialidade = s.IdEspecialidade,
                IdBeneficiario = s.IdBeneficiario,
                DataHoraAgendamento = s.DataHoraAgendamento,
                Ativo = s.Ativo,
            }).ToList();
        }

        public Agendamento Editar(AgendamentoEditarDto agendamento)
        {
            Agendamento agendamentoEntidadeBD =
               (from c in _context.Agendamentos
                where c.IdAgendamento == agendamento.IdAgendamento
                select c)
                ?.FirstOrDefault()
                ?? new Agendamento();

            if (agendamentoEntidadeBD == null || DBNull.Value.Equals(agendamentoEntidadeBD.IdAgendamento) || agendamentoEntidadeBD.IdAgendamento == 0)
            {
                return null;
            }

            Agendamento agendamentoEntidade = new Agendamento()
            {
                IdAgendamento = agendamento.IdAgendamento,
                IdHospital = (agendamento.IdHospital != null ? agendamento.IdHospital : agendamentoEntidadeBD.IdHospital),
                IdEspecialidade = (agendamento.IdEspecialidade != null ? agendamento.IdEspecialidade : agendamentoEntidadeBD.IdEspecialidade),
                IdBeneficiario = (agendamento.IdBeneficiario != null ? agendamento.IdBeneficiario : agendamentoEntidadeBD.IdBeneficiario),
                DataHoraAgendamento = (agendamento.DataHoraAgendamento != null ? agendamento.DataHoraAgendamento : agendamentoEntidadeBD.DataHoraAgendamento),
                Ativo = agendamento.Ativo,
            };

            _context.ChangeTracker.Clear();
            _context.Agendamentos.Update(agendamentoEntidade);
            _context.SaveChanges();
            return agendamentoEntidade;
        }

    }
}


