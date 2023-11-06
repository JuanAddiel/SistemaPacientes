using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPacientes.Core.Application.ViewModels.Paciente
{
    public class PacienteSaveViewModel
    {
        public int Id { get; set;}
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Agregar su Nombre")]
        public string Nombre { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Agregar su Apellido")]
        public string Apellido { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Agregar su Descripcion")]
        public string Direccion { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Agregar su Telefono")]
        public string Telefono { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Agregar su cedula")]
        public string Cedula { get; set; }
        [DataType(DataType.Upload)]
        public IFormFile File { get; set; }
        [Required(ErrorMessage = "Agregar si tiene alergias")]
        public bool Alergias { get; set; }
        [Required(ErrorMessage = "Agregar si fuma")]
        public bool Fuma { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Agregar su fecha de nacimiento")]
        public DateTime FechaNacimiento { get; set; }
        public string? Foto { get; set; }
    }
}
