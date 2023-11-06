using SistemaPacientes.Core.Application.Interfaces.Repositories;
using SistemaPacientes.Core.Application.Interfaces.Services;
using SistemaPacientes.Core.Application.ViewModels.Paciente;
using SistemaPacientes.Core.Application.ViewModels.User;
using SistemaPacientes.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPacientes.Core.Application.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioServices(IUsuarioRepository usuarioRepository) => _usuarioRepository = usuarioRepository;

        public async Task<UserViewModel> Login (LoginViewModel vm)
        {
            var usuario = await _usuarioRepository.Login(vm);
            if(usuario == null)
            {
                return null;
            }
            UserViewModel userViewModel = new();
            userViewModel.Id = usuario.Id;
            userViewModel.Nombre = usuario.Nombre;
            userViewModel.Email = usuario.Email;
            userViewModel.Phone = usuario.Phone;
            userViewModel.UserName = usuario.UserName;
            userViewModel.Password = usuario.Password;
            userViewModel.RoleId = usuario.RoleId;
            return userViewModel;

        }
        public async Task<UserSaveViewModel> AddAsync(UserSaveViewModel saveViewModel)
        {
            Usuario usuario = new();
            usuario.Nombre = saveViewModel.Nombre;
            usuario.Email = saveViewModel.Email;
            usuario.Phone = saveViewModel.Phone;
            usuario.UserName = saveViewModel.UserName;
            usuario.Password = saveViewModel.Password;
            usuario.RoleId = saveViewModel.RoleId;
            await _usuarioRepository.AddAsync(usuario);

            usuario = await _usuarioRepository.GetByIdAsync(usuario.Id);
            saveViewModel.Id = usuario.Id;
            saveViewModel.Nombre = usuario.Nombre;
            saveViewModel.Email = usuario.Email;
            saveViewModel.Phone = usuario.Phone;
            saveViewModel.UserName = usuario.UserName;
            saveViewModel.Password = usuario.Password;
            saveViewModel.RoleId = usuario.RoleId;
            return saveViewModel;

        }

        public async Task DeleteAsync(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            await _usuarioRepository.DeleteAsync(usuario);
        }

        public async Task<ICollection<UserViewModel>> GetAllAsync()
        {
            var usuarios = await _usuarioRepository.GetAllAsyncInclude(new List<string> { "Role" });
            return usuarios.Select(user => new UserViewModel
            {
                Id = user.Id,
                Nombre = user.Nombre,
                UserName = user.UserName,
                Phone = user.Phone,
                Email = user.Email,
                RoleName = user.Role.Name,

            }).ToList();
        }

        public async Task<UserSaveViewModel> GetByIdAsync(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            UserSaveViewModel saveViewModel = new();
            saveViewModel.Id = usuario.Id;
            saveViewModel.Nombre = usuario.Nombre;
            saveViewModel.Email = usuario.Email;
            saveViewModel.Phone = usuario.Phone;
            saveViewModel.UserName = usuario.UserName;
            saveViewModel.Password = usuario.Password;
            saveViewModel.ConfirmPassword = usuario.Password;
            saveViewModel.RoleId = usuario.RoleId;
            return saveViewModel;   
        }

        public async Task UpdateAsync(UserSaveViewModel saveViewModel)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(saveViewModel.Id);
            usuario.Nombre = saveViewModel.Nombre;
            usuario.Email = saveViewModel.Email;
            usuario.Phone = saveViewModel.Phone;
            usuario.UserName = saveViewModel.UserName;
            usuario.Password = saveViewModel.Password;
            usuario.RoleId = saveViewModel.RoleId;
            await _usuarioRepository.UpdateAsync(usuario);
        }
    }
}
