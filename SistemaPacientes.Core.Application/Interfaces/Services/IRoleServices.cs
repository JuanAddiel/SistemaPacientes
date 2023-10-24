using SistemaPacientes.Core.Application.ViewModels.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPacientes.Core.Application.Interfaces.Services
{
    public interface IRoleServices:IGenericServices<RoleSaveViewModel, RoleViewModel>
    {
    }
}
