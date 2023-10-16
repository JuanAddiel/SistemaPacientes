using SistemaPacientes.Core.Application.Interfaces.Repositories;
using SistemaPacientes.Core.Application.Interfaces.Services;
using SistemaPacientes.Core.Application.ViewModels.Cita;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPacientes.Core.Application.Services
{
    public class CitaServices : ICitaServices
    {
        private readonly ICitaRepository _citaRepository;
        public CitaServices(ICitaRepository citaRepository)
        {
            _citaRepository = citaRepository;
        }
        public Task<CitaViewModel> AddAsync(CitaSaveViewModel saveViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<CitaViewModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CitaViewModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CitaViewModel> UpdateAsync(int id, CitaSaveViewModel saveViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
