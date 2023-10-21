using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPacientes.Core.Application.ViewModels.User
{
    public class UserSaveViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El Phone es requerido")]
        [DataType(DataType.Text)]
        public string Phone { get; set; }
        [Required(ErrorMessage = "El Nombre de usuario es requerido")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "El Email es requerido")]
        [DataType(DataType.Text)]
        public string Email { get; set; }
        [Required(ErrorMessage = "La contraseña es requerido")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare(nameof(Password), ErrorMessage = "Las contraseñas no coinciden")]
        [Required(ErrorMessage = "La confirmacion de contraseña es requerido")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
