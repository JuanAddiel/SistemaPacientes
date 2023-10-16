using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPacientes.Core.Application.ViewModels.Paciente
{
    public class PacienteViewModel
    {
        public int Id { get; set;}
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Cedula { get; set; }
        public string Foto { get; set; }
        public bool Alergias { get; set; }
        public bool Fuma { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
