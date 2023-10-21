using SistemaPacientes.Core.Application.Interfaces.Repositories;
using SistemaPacientes.Core.Application.Interfaces.Services;
using SistemaPacientes.Core.Application.ViewModels.ResultadoLaboratorio;
using SistemaPacientes.Core.Domain.Entities;
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

        public async Task<ResultadoLaboratorioSaveViewModel> AddAsync(ResultadoLaboratorioSaveViewModel saveViewModel)
        {
            ResultadoLaboratorio resultado = new();
            resultado.Id = saveViewModel.Id;
            resultado.IdPruebaLaboratorio = saveViewModel.IdPruebaLaboratorio;
            resultado.IdPaciente = saveViewModel.IdPaciente;
            resultado.Estado = saveViewModel.Estado;
            resultado = await _resultadoRepository.AddAsync(resultado);

            ResultadoLaboratorioSaveViewModel resultadoSaveViewModel = new();
            resultadoSaveViewModel.Id = resultado.Id;
            resultadoSaveViewModel.IdPruebaLaboratorio = resultado.IdPruebaLaboratorio;
            resultadoSaveViewModel.IdPaciente = resultado.IdPaciente;
            resultadoSaveViewModel.Estado = resultado.Estado;
            return resultadoSaveViewModel;
        }

        public async Task DeleteAsync(int id)
        {
            var resultado = await _resultadoRepository.GetByIdAsync(id);
            await _resultadoRepository.DeleteAsync(resultado);
        }

        public async Task<ICollection<ResultadoLaboratorioViewModel>> GetAllAsync()
        {
            var resultado = await _resultadoRepository.GetAllAsyncInclude(new List<string> { "PruebaLaboratorio", "Paciente" });
            return resultado.Select(r=>new ResultadoLaboratorioViewModel
            {
                Id = r.Id,
                IdPruebaLaboratorio = r.IdPruebaLaboratorio,
                IdPaciente = r.IdPaciente,
                Estado = r.Estado,
                NombrePruebaLaboratorio = r.PruebaLaboratorio.Nombre,
                NombrePaciente = r.Paciente.Nombre,
                ApellidoPaciente = r.Paciente.Apellido,
            }).ToList();
        }

        public async Task<ResultadoLaboratorioSaveViewModel> GetByIdAsync(int id)
        {
            var resultado = await _resultadoRepository.GetByIdAsync(id);
            ResultadoLaboratorioSaveViewModel resultadoSaveViewModel = new();
            resultadoSaveViewModel.Id = resultado.Id;
            resultadoSaveViewModel.IdPruebaLaboratorio = resultado.IdPruebaLaboratorio;
            resultadoSaveViewModel.IdPaciente = resultado.IdPaciente;
            resultadoSaveViewModel.Estado = resultado.Estado;
            return resultadoSaveViewModel;
        }

        public async Task UpdateAsync(ResultadoLaboratorioSaveViewModel saveViewModel)
        {
            ResultadoLaboratorio resultado = await _resultadoRepository.GetByIdAsync(saveViewModel.Id);
            resultado.Id = saveViewModel.Id;
            resultado.IdPruebaLaboratorio = saveViewModel.IdPruebaLaboratorio;
            resultado.IdPaciente = saveViewModel.IdPaciente;
            resultado.Estado = saveViewModel.Estado;

            await _resultadoRepository.UpdateAsync(resultado);
        }
    }
}
