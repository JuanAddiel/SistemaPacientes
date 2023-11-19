using SistemaPacientes.Core.Application.ViewModels.Medico;
using SistemaPacientes.Core.Application.ViewModels.Paciente;
using SistemaPacientes.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPacientes.Core.Application.ViewModels.Cita
{
    public class CitaSaveViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int IdPaciente { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int IdMedico { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DataType(DataType.Date)]
        public string FechaCita { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DataType(DataType.Time)]
        public string HoraCita { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DataType(DataType.MultilineText)]
        public string MotivoCita { get; set; }
        public bool Estado { get; set; }
        public ICollection<MedicoViewModel>? medicos { get; set; }
        public ICollection<PacienteViewModel>? pacientes { get; set; }
    }
}
