using SistemaPacientes.Core.Application.Interfaces.Repositories;
using SistemaPacientes.Core.Application.Interfaces.Services;
using SistemaPacientes.Core.Application.ViewModels.Paciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPacientes.Core.Application.Services
{
    public class PacienteServices : IPacienteServices
    {
        private readonly IPacienteRepository _pacienteRepository;
        public PacienteServices(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }
        public Task<PacienteViewModel> AddAsync(PacienteSaveViewModel saveViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<PacienteViewModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PacienteViewModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PacienteViewModel> UpdateAsync(int id, PacienteSaveViewModel saveViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
