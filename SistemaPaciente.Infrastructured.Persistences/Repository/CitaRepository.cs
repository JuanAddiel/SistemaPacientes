using SistemaPacientes.Infrastructure.Persistence.Context;
using SistemaPacientes.Core.Application.Interfaces.Repositories;
using SistemaPacientes.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPacientes.Infrastructure.Persistence.Repository
{
    public class CitaRepository :GenericRepository<Cita>, ICitaRepository
    {
        private readonly SistemaPacienteContext _context;
        public CitaRepository(SistemaPacienteContext context) : base(context) => _context = context;
    }
}
