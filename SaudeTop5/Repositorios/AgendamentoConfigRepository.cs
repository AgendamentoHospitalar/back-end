using SaudeTop5.Context;
using SaudeTop5.Dto.AgendamentoConfiguracao;
using SaudeTop5.Entidade;
using SaudeTop5.Interfaces;

namespace SaudeTop5.Repositorios
{
    public class AgendamentoConfigRepository : IAgendamentoConfiguracaoRepository
    {
        private readonly DatabaseContext _context;
        public AgendamentoConfigRepository(DatabaseContext context)
        {
            _context = context;
        }
        public AgendamentoConfiguracao Criar(AgendamentoConfigCriarDto agendamentoConfig)
        {
            AgendamentoConfiguracao AgendamentoConfigEntidade = new AgendamentoConfiguracao()
            {
                IdConfiguracao = agendamentoConfig.IdConfiguracao,
                IdHospital = agendamentoConfig.IdHospital,
                IdEspecialidade = agendamentoConfig.IdEspecialidade,
                IdProfissional = agendamentoConfig.IdProfissional,
                DataHoraInicioAtendimento = agendamentoConfig.DataHoraInicioAtendimento,
                DataHoraFinalAtendimento = agendamentoConfig.DataHoraFinalAtendimento

            };

            _context.ChangeTracker.Clear();
            _context.AgendamentoConfiguracaos.Add(AgendamentoConfigEntidade);
            _context.SaveChanges();
            return AgendamentoConfigEntidade;
        }

        public AgendamentoConfiguracao Editar(AgendamentoConfigEditarDto agendamentoConfig)
        {
            AgendamentoConfiguracao agendamentoConfigEntidadeBD =
            (from c in _context.AgendamentoConfiguracaos
             where c.IdConfiguracao == agendamentoConfig.IdConfiguracao
             select c)
             ?.FirstOrDefault()
             ?? new AgendamentoConfiguracao();

            if (agendamentoConfigEntidadeBD == null || DBNull.Value.Equals(agendamentoConfigEntidadeBD.IdConfiguracao) || agendamentoConfigEntidadeBD.IdConfiguracao == 0)
            {
                return null;
            }

            AgendamentoConfiguracao agendamentoConfigEntidade = new AgendamentoConfiguracao()
            {
                IdConfiguracao = agendamentoConfig.IdConfiguracao,

            };

            _context.ChangeTracker.Clear();
            _context.AgendamentoConfiguracaos.Update(agendamentoConfigEntidade);
            _context.SaveChanges();
            return agendamentoConfigEntidade;
        }



        public int Excluir(int Id)
        {
            var agendamentoConfig = new AgendamentoConfiguracao()
            {
                IdConfiguracao = Id
            };

            _context.AgendamentoConfiguracaos.Remove(agendamentoConfig);
            return _context.SaveChanges();
        }

        public AgendamentoConfigDto ListarPorId(int id)
        {
            return (from t in _context.AgendamentoConfiguracaos
                    where t.IdConfiguracao == id
                    select new AgendamentoConfigDto()
                    {
                        IdConfiguracao = t.IdConfiguracao,
                        IdEspecialidade = t.IdEspecialidade,
                        IdHospital = t.IdHospital,
                        IdProfissional = t.IdProfissional,
                        DataHoraInicioAtendimento = t.DataHoraInicioAtendimento,
                        DataHoraFinalAtendimento = t.DataHoraFinalAtendimento

                    })
                   ?.FirstOrDefault()
                   ?? new AgendamentoConfigDto();
        }

        public List<AgendamentoConfigDto> ListarTodos()
        {
            return _context.AgendamentoConfiguracaos.Select(s => new AgendamentoConfigDto()
            {
                IdConfiguracao = s.IdConfiguracao,
                IdEspecialidade = s.IdEspecialidade,
                IdHospital = s.IdHospital,
                IdProfissional = s.IdProfissional,
                DataHoraInicioAtendimento = s.DataHoraInicioAtendimento,
                DataHoraFinalAtendimento = s.DataHoraFinalAtendimento

            }).ToList();
        }
    }
}
