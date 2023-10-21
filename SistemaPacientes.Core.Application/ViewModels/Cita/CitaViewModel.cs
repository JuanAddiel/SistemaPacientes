using SistemaPacientes.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPacientes.Core.Application.ViewModels.Cita
{
    public class CitaViewModel
    {
        public int Id { get; set; }
        public int IdPaciente { get; set; }
        public int IdMedico { get; set; }
        public string FechaCita { get; set; }
        public string HoraCita { get; set; }
        public string MotivoCita { get; set; }
        public bool Estado { get; set; }
        public string NombrePaciente { get; set; }
        public string NombreMedico { get; set; }
    }
}
