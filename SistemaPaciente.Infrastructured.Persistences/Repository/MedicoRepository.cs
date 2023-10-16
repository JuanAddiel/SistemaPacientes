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
    public class MedicoRepository:GenericRepository<Medico>, IMedicoRepository
    {
        private readonly SistemaPacienteContext _context;
        public MedicoRepository(SistemaPacienteContext context) : base(context) => _context = context;
    }
}
