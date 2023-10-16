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
    public class PacienteRepository:GenericRepository<Paciente>, IPacienteRepository
    {
        private readonly SistemaPacienteContext _context;
        public PacienteRepository(SistemaPacienteContext context) : base(context) => _context = context;
    }
}
