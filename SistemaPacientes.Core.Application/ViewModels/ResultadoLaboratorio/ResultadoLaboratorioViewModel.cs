using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPacientes.Core.Application.ViewModels.ResultadoLaboratorio
{
    public class ResultadoLaboratorioViewModel
    {
        public int Id { get; set; }
        public int IdPruebaLaboratorio { get; set; }
        public int IdPaciente { get; set; }
        public bool Estado { get; set; }
    }
}
