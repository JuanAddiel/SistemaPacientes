using SistemaPacientes.Core.Application.ViewModels.ResultadoLaboratorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPacientes.Core.Application.Interfaces.Services
{
    public interface IResultadoServices:IGenericServices<ResultadoLaboratorioSaveViewModel, ResultadoLaboratorioViewModel>
    {
    }
}
