using SistemaPacientes.Core.Application.ViewModels.Cita;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPacientes.Core.Application.Interfaces.Services
{
    public interface ICitaServices:IGenericServices<CitaSaveViewModel, CitaViewModel>
    {
    }
}
