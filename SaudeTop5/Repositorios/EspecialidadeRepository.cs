using SaudeTop5.Context;
using SaudeTop5.Dto.Especialidade;
using SaudeTop5.Entidade;
using SaudeTop5.Interfaces;

namespace SaudeTop5.Repositorios
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        private readonly DatabaseContext _context;
        public EspecialidadeRepository(DatabaseContext context)
        {
            _context = context;
        }
        public Especialidade Criar(EspecialidadeCriarDto especialidade)
        {
            Especialidade especialidadeEntidade = new Especialidade()
            {
                Nome = especialidade.Nome,
                Descricao = especialidade.Descricao,
                Ativo = especialidade.Ativo,
            };

            _context.ChangeTracker.Clear();
            _context.Especialidades.Add(especialidadeEntidade);
            _context.SaveChanges();
            return especialidadeEntidade;
        }

        public Especialidade Editar(EspecialidadeEditarDto especialidade)
        {
            Especialidade especialidadeEntidadeBD =
            (from c in _context.Especialidades
             where c.IdEspecialidade == especialidade.IdEspecialidade
             select c)
             ?.FirstOrDefault()
             ?? new Especialidade();

            if (especialidadeEntidadeBD == null || DBNull.Value.Equals(especialidadeEntidadeBD.IdEspecialidade) || especialidadeEntidadeBD.IdEspecialidade == 0)
            {
                return null;
            }

            Especialidade especialidadeEntidade = new Especialidade()
            {
                IdEspecialidade = especialidade.IdEspecialidade,
                Nome = (especialidade.Nome != null ? especialidade.Nome : especialidadeEntidadeBD.Nome),
                Descricao = (especialidade.Descricao != null ? especialidade.Descricao : especialidadeEntidadeBD.Descricao),
                Ativo = especialidade.Ativo,
            };

            _context.ChangeTracker.Clear();
            _context.Especialidades.Update(especialidadeEntidade);
            _context.SaveChanges();
            return especialidadeEntidade;
        }

        public int Excluir(int Id)
        {
            var especialidade = new Especialidade()
            {
                IdEspecialidade = Id
            };

            _context.Especialidades.Remove(especialidade);
            return _context.SaveChanges();
        }

        public EspecialidadeDto ListarPorId(int id)
        {
            return (from t in _context.Especialidades
                    where t.IdEspecialidade == id
                    select new EspecialidadeDto()
                    {
                        IdEspecialidade = t.IdEspecialidade,
                        Nome = t.Nome,
                        Descricao = t.Descricao,
                        Ativo = t.Ativo,
                    })
         ?.FirstOrDefault()
         ?? new EspecialidadeDto();
        }

        public List<EspecialidadeDto> ListarTodos()
        {
            return _context.Especialidades.Select(s => new EspecialidadeDto()
            {
                IdEspecialidade = s.IdEspecialidade,
                Nome = s.Nome,
                Descricao = s.Descricao,
                Ativo = s.Ativo,
            }).ToList();
        }
    }
}
