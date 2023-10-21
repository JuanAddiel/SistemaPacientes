using SistemaPacientes.Core.Application.ViewModels.User;
using SistemaPacientes.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPacientes.Core.Application.Interfaces.Repositories
{
    public interface IUsuarioRepository:IGenericRepository<Usuario>
    {
        Task<Usuario> Login(LoginViewModel loginView);
    }
}
