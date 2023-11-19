using SistemaPacientes.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPacientes.Core.Domain.Entities
{
    public class ResultadoLaboratorio:AuditableBaseEntity
    {
        public Cita Cita { get; set; }
        public PruebaLaboratorio pruebaLaboratorio { get; set; }
        public Paciente paciente { get; set; }
        public int? IdPaciente { get; set; }
        public int IdPruebaL { get; set; }
        public int IdCita { get; set; }
        public bool Estado { get; set; }
    }
}
