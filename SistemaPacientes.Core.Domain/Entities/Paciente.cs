using SistemaPacientes.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPacientes.Core.Domain.Entities
{
    public class Paciente: AuditableBaseEntity
    {
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Cedula { get; set; }  
        public string Foto { get; set; }
        public bool Alergias { get; set; }
        public bool Fuma { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public ICollection<Cita> Citas { get; set; }
        public ICollection<ResultadoLaboratorio> ResultadoLaboratorios { get; set; }
    }
}
