﻿using SistemaPacientes.Core.Application.ViewModels.Medico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPacientes.Core.Application.Interfaces.Services
{
    public interface IMedicoServices:IGenericServices<MedicoSaveViewModel, MedicoViewModel>
    {
    }
}
