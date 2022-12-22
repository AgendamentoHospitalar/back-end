using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SaudeTop5.Entidade;

namespace SaudeTop5.Context
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agendamento> Agendamentos { get; set; } = null!;
        public virtual DbSet<AgendamentoConfiguracao> AgendamentoConfiguracaos { get; set; } = null!;
        public virtual DbSet<Beneficiario> Beneficiarios { get; set; } = null!;
        public virtual DbSet<DadosBancario> DadosBancarios { get; set; } = null!;
        public virtual DbSet<Especialidade> Especialidades { get; set; } = null!;
        public virtual DbSet<Hospital> Hospitals { get; set; } = null!;
        public virtual DbSet<Profissional> Profissionals { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=WINAPGHRNEI8KH3;Initial Catalog=Projeto;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agendamento>(entity =>
            {
                entity.HasOne(d => d.IdBeneficiarioNavigation)
                    .WithMany(p => p.Agendamentos)
                    .HasForeignKey(d => d.IdBeneficiario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Agendamento_Beneficiario");

                entity.HasOne(d => d.IdEspecialidadeNavigation)
                    .WithMany(p => p.Agendamentos)
                    .HasForeignKey(d => d.IdEspecialidade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Agendamento_Especialidade");

                entity.HasOne(d => d.IdHospitalNavigation)
                    .WithMany(p => p.Agendamentos)
                    .HasForeignKey(d => d.IdHospital)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Agendamento_Hospital");

                entity.HasOne(d => d.IdProfissionalNavigation)
                    .WithMany(p => p.Agendamentos)
                    .HasForeignKey(d => d.IdProfissional)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Agendamento_Profissional");
            });

            modelBuilder.Entity<AgendamentoConfiguracao>(entity =>
            {
                entity.HasOne(d => d.IdEspecialidadeNavigation)
                    .WithMany(p => p.AgendamentoConfiguracaos)
                    .HasForeignKey(d => d.IdEspecialidade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AgendamentoConfiguracao_Especialidade");

                entity.HasOne(d => d.IdHospitalNavigation)
                    .WithMany(p => p.AgendamentoConfiguracaos)
                    .HasForeignKey(d => d.IdHospital)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AgendamentoConfiguracao_Hospital");

                entity.HasOne(d => d.IdProfissionalNavigation)
                    .WithMany(p => p.AgendamentoConfiguracaos)
                    .HasForeignKey(d => d.IdProfissional)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AgendamentoConfiguracao_Profissional");
            });

            modelBuilder.Entity<DadosBancario>(entity =>
            {
                entity.HasOne(d => d.IdProfissionalNavigation)
                    .WithMany(p => p.DadosBancarios)
                    .HasForeignKey(d => d.IdProfissional)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DadosBancarios_Profissional");
            });

            modelBuilder.Entity<Hospital>(entity =>
            {
                entity.HasKey(e => e.IdHospital)
                    .HasName("PK__Hospital__AF70C2B21C7D6D48");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
