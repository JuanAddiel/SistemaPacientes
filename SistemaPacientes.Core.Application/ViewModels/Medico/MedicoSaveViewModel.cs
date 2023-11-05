using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPacientes.Core.Application.ViewModels.Medico
{
    public class MedicoSaveViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Agregar Nombre")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Agregar Apellido")]
        [DataType(DataType.Text)]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Agregar Correo")]
        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }
        [Required(ErrorMessage = "Agregar Telefono")]
        [DataType(DataType.Text)]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Agregar Cedula")]
        [DataType(DataType.Text)]
        public string Cedula { get; set; }
        public string? Foto { get; set; }
        [DataType(DataType.Upload)]
        public IFormFile File { get; set; }
    }
}
