using SistemaPacientes.Core.Application.Interfaces.Repositories;
using SistemaPacientes.Core.Application.Interfaces.Services;
using SistemaPacientes.Core.Application.ViewModels.PruebaLaboratorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPacientes.Core.Application.Services
{
    public class PruebaLaboratorioServices:IPruebaServices
    {
        private readonly IPruebaRepository _pruebaRepository;
        public PruebaLaboratorioServices(IPruebaRepository pruebaRepository)
        {
            _pruebaRepository = pruebaRepository;
        }

        public Task<PruebaLaboratorioViewModel> AddAsync(PruebaLaboratorioSaveViewModel saveViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<PruebaLaboratorioViewModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PruebaLaboratorioViewModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PruebaLaboratorioViewModel> UpdateAsync(int id, PruebaLaboratorioSaveViewModel saveViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
