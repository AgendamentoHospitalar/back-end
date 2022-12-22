using SaudeTop5.Context;
using SaudeTop5.Dto.Hospital;
using SaudeTop5.Entidade;
using SaudeTop5.Interfaces;

namespace SaudeTop5.Repositorios
{
    public class HospitalRepository : IHospitalRepository
    {
        private readonly DatabaseContext _context;
        public HospitalRepository(DatabaseContext context)
        {
            _context = context;
        }
        public Hospital Criar(HospitalCriarDto hospital)
        {
            Hospital hospitalEntidade = new Hospital()
            {
                Nome = hospital.Nome,
                Cnpj = hospital.Cnpj,
                Telefone = hospital.Telefone,
                Endereco = hospital.Endereco,
                Cnes = hospital.Cnes,
                Ativo = hospital.Ativo,

            };

            _context.ChangeTracker.Clear();
            _context.Hospitals.Add(hospitalEntidade);
            _context.SaveChanges();
            return hospitalEntidade;
        }

        public Hospital Editar(HospitalEditarDto hospital)
        {
            Hospital hospitalEntidadeBD =
            (from c in _context.Hospitals
             where c.IdHospital == hospital.IdHospital
             select c)
             ?.FirstOrDefault()
             ?? new Hospital();

            if (hospitalEntidadeBD == null || DBNull.Value.Equals(hospitalEntidadeBD.IdHospital) || hospitalEntidadeBD.IdHospital == 0)
            {
                return null;
            }

            Hospital hospitalEntidade = new Hospital()
            {
                IdHospital = hospital.IdHospital,
                Nome = (hospital.Nome != null ? hospital.Nome : hospitalEntidadeBD.Nome),
                Cnpj = (hospital.Cnpj != null ? hospital.Cnpj : hospitalEntidadeBD.Cnpj),
                Cnes = (hospital.Cnes != null ? hospital.Cnes : hospitalEntidadeBD.Cnes),
                Telefone = (hospital.Telefone != null ? hospital.Telefone : hospitalEntidadeBD.Telefone),
                Endereco = (hospital.Endereco != null ? hospital.Endereco : hospitalEntidadeBD.Endereco),
                Ativo = hospital.Ativo,

            };

            _context.ChangeTracker.Clear();
            _context.Hospitals.Update(hospitalEntidade);
            _context.SaveChanges();
            return hospitalEntidade;
        }


        public int Excluir(int Id)
        {
            var hospital = new Hospital()
            {
                IdHospital = Id
            };

            _context.Hospitals.Remove(hospital);
            return _context.SaveChanges();
        }

        public HospitalDto ListarPorId(int id)
        {
            return (from t in _context.Hospitals
                    where t.IdHospital == id
                    select new HospitalDto()
                    {
                        IdHospital = t.IdHospital,
                        Nome = t.Nome,
                        Cnpj = t.Cnpj,
                        Telefone = t.Telefone,
                        Endereco = t.Endereco,
                        Cnes = t.Cnes,
                        Ativo = t.Ativo,


                    })
                      ?.FirstOrDefault()
                      ?? new HospitalDto();
        }

        public List<HospitalDto> ListarTodos()
        {
            return _context.Hospitals.Select(s => new HospitalDto()
            {
                IdHospital = s.IdHospital,
                Nome = s.Nome,
                Cnpj = s.Cnpj,
                Telefone = s.Telefone,
                Endereco = s.Endereco,
                Cnes = s.Cnes,
                Ativo = s.Ativo,


            }).ToList();
        }
    }
}
