using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPacientes.Core.Domain.Entities
{
    public class ResultadoLaboratorio
    {
        public int Id { get; set; }
        public int IdPruebaLaboratorio { get; set; }
        public PruebaLaboratorio PruebaLaboratorio { get; set; }
        public int IdPaciente { get; set; }
        public Paciente Paciente { get; set; }
        public string Estado { get; set; }
    }
}
