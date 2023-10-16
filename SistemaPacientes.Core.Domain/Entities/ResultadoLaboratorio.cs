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
        public int IdPruebaLaboratorio { get; set; }
        public PruebaLaboratorio PruebaLaboratorio { get; set; }
        public int IdPaciente { get; set; }
        public Paciente Paciente { get; set; }
        public bool Estado { get; set; }
    }
}
