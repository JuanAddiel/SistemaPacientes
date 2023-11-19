using SistemaPacientes.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPacientes.Core.Domain.Entities
{
    public class Cita: AuditableBaseEntity
    {
        public int IdPaciente { get; set; }
        public Paciente Paciente { get; set; }
        public int IdMedico { get; set; }
        public Medico Medico { get; set; }
        public string FechaCita { get; set; }
        public string HoraCita { get; set; }
        public string MotivoCita { get; set; }
        public bool Estado { get; set; }
        public ICollection<ResultadoLaboratorio> ResultadosLaboratorio { get; set; }
    }
}
