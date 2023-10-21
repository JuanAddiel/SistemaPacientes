using Microsoft.EntityFrameworkCore;
using SistemaPacientes.Core.Application.Helpers;
using SistemaPacientes.Core.Application.Interfaces.Repositories;
using SistemaPacientes.Core.Application.ViewModels.User;
using SistemaPacientes.Core.Domain.Entities;
using SistemaPacientes.Infrastructure.Persistence.Context;

namespace SistemaPacientes.Infrastructure.Persistence.Repository
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        private readonly SistemaPacienteContext _context;
        public UsuarioRepository(SistemaPacienteContext context) : base(context) => _context = context;

        public override async Task<Usuario> AddAsync(Usuario usuario)
        {
            usuario.Password = PasswordEncryption.EncryptionPass(usuario.Password);
            await base.AddAsync(usuario);
            return usuario;
        } 

        public async Task<Usuario> Login(LoginViewModel loginVm)
        {
            string password = PasswordEncryption.EncryptionPass(loginVm.Password);
            Usuario usuario = await _context.Set<Usuario>().FirstOrDefaultAsync(u => u.UserName == loginVm.UserName && u.Password == password);
            return usuario;
        }
    }
}
