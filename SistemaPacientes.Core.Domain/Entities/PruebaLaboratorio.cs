using SistemaPacientes.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPacientes.Core.Domain.Entities
{
    public class PruebaLaboratorio: AuditableBaseEntity
    {
        public string Nombre { get; set; }
        public ICollection<ResultadoLaboratorio> ResultadoLaboratorios { get; set; }
    }
}
