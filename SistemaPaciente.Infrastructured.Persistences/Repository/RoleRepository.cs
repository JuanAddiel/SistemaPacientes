using SistemaPacientes.Core.Application.Interfaces.Repositories;
using SistemaPacientes.Core.Domain.Entities;
using SistemaPacientes.Infrastructure.Persistence.Context;
using SistemaPacientes.Infrastructure.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPacientes.Infrastructure.Persistence.Repository
{
    public class RoleRepository:GenericRepository<Role>, IRoleRepository
    {
        private readonly SistemaPacienteContext _context;
        public RoleRepository(SistemaPacienteContext context):base(context)=>_context=context;
    }
}
