using SistemaPacientes.Core.Application.ViewModels.Paciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPacientes.Core.Application.Interfaces.Services
{
    public interface IPacienteServices:IGenericServices<PacienteSaveViewModel, PacienteViewModel>
    {
    }
}
