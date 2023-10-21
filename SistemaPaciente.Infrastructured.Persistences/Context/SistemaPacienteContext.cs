using Microsoft.EntityFrameworkCore;
using SistemaPacientes.Core.Application.ViewModels.User;
using SistemaPacientes.Core.Domain.Common;
using SistemaPacientes.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPacientes.Infrastructure.Persistence.Context
{
    public class SistemaPacienteContext: DbContext
    {
        public SistemaPacienteContext(DbContextOptions<SistemaPacienteContext> options) : base(options)
        {
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.Now;
                        entry.Entity.CreatedBy = "Default";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedAt = DateTime.Now;
                        entry.Entity.LastModifiedBy = "Default";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        public DbSet<Paciente> pacientes { get; set; }
        public DbSet<Cita> citas { get; set; }
        public DbSet<Medico> medicos { get; set; }
        public DbSet<PruebaLaboratorio> pruebaLaboratorios { get; set; }
        public DbSet<ResultadoLaboratorio> resultadoLaboratorios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Tables
            modelBuilder.Entity<Paciente>().ToTable("Paciente");
            modelBuilder.Entity<Cita>().ToTable("Cita");
            modelBuilder.Entity<Medico>().ToTable("Medico");
            modelBuilder.Entity<PruebaLaboratorio>().ToTable("PruebaLaboratorio");
            modelBuilder.Entity<ResultadoLaboratorio>().ToTable("ResultadoLaboratorio");
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            #endregion
            #region Primary Key
            modelBuilder.Entity<Paciente>().HasKey(p => p.Id);
            modelBuilder.Entity<Cita>().HasKey(p => p.Id);
            modelBuilder.Entity<Medico>().HasKey(p => p.Id);
            modelBuilder.Entity<PruebaLaboratorio>().HasKey(p => p.Id);
            modelBuilder.Entity<ResultadoLaboratorio>().HasKey(p => p.Id);
            modelBuilder.Entity<Usuario>().HasKey(p => p.Id);
            #endregion
            #region Foreign Key 
            modelBuilder.Entity<Paciente>()
                .HasMany<Cita>(p => p.Citas)
                .WithOne( p => p.Paciente)
                .HasForeignKey(p => p.IdPaciente)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Medico>()
                .HasMany<Cita>(p => p.citas)
                .WithOne(p => p.Medico)
                .HasForeignKey(p => p.IdMedico)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Paciente>()
                .HasMany<ResultadoLaboratorio>(r => r.ResultadoLaboratorios)
                .WithOne(p=>p.Paciente)
                .HasForeignKey(p => p.IdPaciente)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PruebaLaboratorio>()
                .HasMany<ResultadoLaboratorio>(r => r.ResultadoLaboratorio)
                .WithOne(p => p.PruebaLaboratorio)  
                .HasForeignKey(p => p.IdPruebaLaboratorio)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion
            #region Properties
            #region Usuario
            modelBuilder.Entity<Usuario>(u =>
            {
                u.Property(u => u.Nombre).HasMaxLength(75).IsRequired();
                u.Property(u => u.Phone).HasMaxLength(13).IsRequired();
                u.Property(u => u.UserName).HasMaxLength(75).IsRequired();
                u.Property(u => u.Email).IsRequired();
                u.Property(u => u.Password).IsRequired();
            });
            #endregion
            #region Paciente
            modelBuilder.Entity<Paciente>(p =>
            {
                p.Property(p => p.Nombre).HasMaxLength(75).IsRequired();
                p.Property(p => p.Apellido).HasMaxLength(75).IsRequired();
                p.Property(p => p.Direccion).HasMaxLength(75).IsRequired();
                p.Property(p => p.Telefono).HasMaxLength(13).IsRequired();
                p.Property(p => p.Cedula).HasMaxLength(13).IsRequired();
                p.Property(p => p.Foto);
                p.Property(p => p.Alergias).IsRequired();
                p.Property(p => p.Fuma).IsRequired();
                p.Property(p => p.FechaNacimiento).IsRequired();
            });
            #endregion
            #region Medico
            modelBuilder.Entity<Medico>(m =>
            {
                m.Property(m => m.Nombre).HasMaxLength(75).IsRequired();
                m.Property(m => m.Apellido).HasMaxLength(75).IsRequired();
                m.Property(m => m.Correo).HasMaxLength(75).IsRequired();
                m.Property(m => m.Telefono).HasMaxLength(13).IsRequired();
                m.Property(m => m.Cedula).HasMaxLength(13).IsRequired();
                m.Property(m => m.Foto);
            });
            #endregion
            #region Cita
            modelBuilder.Entity<Cita>(c =>
            {
                c.Property(c => c.FechaCita).IsRequired();
                c.Property(c => c.HoraCita).IsRequired();
                c.Property(c => c.Estado).IsRequired();
                c.Property(c => c.MotivoCita).IsRequired();
            });
            #endregion
            #region PruebaLaboratorio
            modelBuilder.Entity<PruebaLaboratorio>()
                .Property(p => p.Nombre).HasMaxLength(75).IsRequired();
            #endregion
            #region ResultadoLaboratorio
            modelBuilder.Entity<ResultadoLaboratorio>(r =>
            {
                r.Property(r => r.Estado).IsRequired();
            });
            #endregion
            #endregion
        }

    }
}
