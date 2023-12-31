﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SistemaPacientes.Core.Application.Helpers;
using SistemaPacientes.Core.Application.ViewModels.User;
using SistemaPacientes.Core.Domain.Common;
using SistemaPacientes.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPacientes.Infrastructure.Persistence.Context
{
    public class SistemaPacienteContext: DbContext
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserViewModel user;
        public SistemaPacienteContext(DbContextOptions<SistemaPacienteContext> options/*, IHttpContextAccessor httpContext*/) : base(options)
        {
            //_httpContext = httpContext;
            //user = _httpContext.HttpContext.Session.Get<UserViewModel>("user");
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.Now;
                        entry.Entity.CreatedBy = "Juan";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedAt = DateTime.Now;
                        entry.Entity.LastModifiedBy = "Juan";
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
        public DbSet<Role> Role { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Tables
            modelBuilder.Entity<Paciente>().ToTable("Paciente");
            modelBuilder.Entity<Cita>().ToTable("Cita");
            modelBuilder.Entity<Medico>().ToTable("Medico");
            modelBuilder.Entity<PruebaLaboratorio>().ToTable("PruebaLaboratorio");
            modelBuilder.Entity<ResultadoLaboratorio>().ToTable("ResultadoLaboratorio");
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Role>().ToTable("Role");
            #endregion
            #region Primary Key
            modelBuilder.Entity<Paciente>().HasKey(p => p.Id);
            modelBuilder.Entity<Cita>().HasKey(p => p.Id);
            modelBuilder.Entity<Medico>().HasKey(p => p.Id);
            modelBuilder.Entity<PruebaLaboratorio>().HasKey(p => p.Id);
            modelBuilder.Entity<ResultadoLaboratorio>().HasKey(p => p.Id);
            modelBuilder.Entity<Usuario>().HasKey(p => p.Id);
            modelBuilder.Entity<Role>().HasKey(p => p.Id);
            #endregion
            #region Foreign Key 


            modelBuilder.Entity<Paciente>()
                .HasMany<Cita>(p => p.Citas)
                .WithOne( p => p.Paciente)
                .HasForeignKey(p => p.IdPaciente)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Paciente>()
                .HasMany<ResultadoLaboratorio>(p => p.ResultadoLaboratorios)
                .WithOne(p => p.paciente)
                .HasForeignKey(p => p.IdPaciente)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Cita>()
                .HasMany<ResultadoLaboratorio>(p => p.ResultadosLaboratorio)
                .WithOne(p => p.Cita)
                .HasForeignKey(p => p.IdCita)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<PruebaLaboratorio>()
                .HasMany<ResultadoLaboratorio>(p => p.ResultadoLaboratorios)
                .WithOne(p => p.pruebaLaboratorio)
                .HasForeignKey(p => p.IdPruebaL)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Medico>()
                .HasMany<Cita>(p => p.citas)
                .WithOne(p => p.Medico)
                .HasForeignKey(p => p.IdMedico)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Role>()
                .HasMany<Usuario>(Role => Role.Usuarios)
                .WithOne(Usuario => Usuario.Role)
                .HasForeignKey(Usuario => Usuario.RoleId)
                .OnDelete(DeleteBehavior.NoAction);

            #endregion
            #region Properties
            #region Role
            modelBuilder.Entity<Role>(r =>
            {
                r.Property(r => r.Name).HasMaxLength(75).IsRequired();
                r.Property(r => r.Description).HasMaxLength(75).IsRequired();
            });
            #endregion
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
