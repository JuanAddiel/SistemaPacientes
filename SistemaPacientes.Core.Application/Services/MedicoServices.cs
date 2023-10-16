using SistemaPacientes.Core.Application.Interfaces.Repositories;
using SistemaPacientes.Core.Application.Interfaces.Services;
using SistemaPacientes.Core.Application.ViewModels.Medico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPacientes.Core.Application.Services
{
    public class MedicoServices : IMedicoServices
    {
        private readonly IMedicoRepository _medicoRepository;
        public MedicoServices(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }
        public Task<MedicoViewModel> AddAsync(MedicoSaveViewModel saveViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<MedicoViewModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<MedicoViewModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<MedicoViewModel> UpdateAsync(int id, MedicoSaveViewModel saveViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
