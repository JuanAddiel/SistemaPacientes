using SistemaPacientes.Core.Application.Interfaces.Repositories;
using SistemaPacientes.Core.Application.Interfaces.Services;
using SistemaPacientes.Core.Application.ViewModels.Role;
using SistemaPacientes.Core.Application.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPacientes.Core.Application.Services
{
    public class RoleServices:IRoleServices
    {
        private readonly IRoleRepository _roleRepository;
        public RoleServices(IRoleRepository roleRepository)=>_roleRepository=roleRepository;

        public Task<RoleSaveViewModel> AddAsync(RoleSaveViewModel saveViewModel)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<RoleViewModel>> GetAllAsync()
        {
            var role = await _roleRepository.GetAllAsyncInclude(new List<string> { "Usuarios" });
            return role.Select(c => new RoleViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                //AnuncioQuantity = c.Anuncio.Where(a => a.UsuarioId == userViewModel.Id).Count()
            }).ToList();
        }

        public Task<RoleSaveViewModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(RoleSaveViewModel saveViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
