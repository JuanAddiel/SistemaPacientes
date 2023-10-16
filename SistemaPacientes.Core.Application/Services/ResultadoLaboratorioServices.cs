using SistemaPacientes.Core.Application.Interfaces.Repositories;
using SistemaPacientes.Core.Application.Interfaces.Services;
using SistemaPacientes.Core.Application.ViewModels.ResultadoLaboratorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPacientes.Core.Application.Services
{
    public class ResultadoLaboratorioServices:IResultadoServices
    {
        private readonly IResultadoRepository _resultadoRepository;
        public ResultadoLaboratorioServices(IResultadoRepository resultadoRepository)
        {
            _resultadoRepository = resultadoRepository;
        }

        public Task<ResultadoLaboratorioViewModel> AddAsync(ResultadoLaboratorioSaveViewModel saveViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<ResultadoLaboratorioViewModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResultadoLaboratorioViewModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResultadoLaboratorioViewModel> UpdateAsync(int id, ResultadoLaboratorioSaveViewModel saveViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
