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
        private readonly ICitaRepository _citaRepository;
        public ResultadoLaboratorioServices(IResultadoRepository resultadoRepository, ICitaRepository citaRepository)
        {
            _resultadoRepository = resultadoRepository;
            _citaRepository = citaRepository;
        }

        public async Task<ResultadoLaboratorioSaveViewModel> AddAsync(ResultadoLaboratorioSaveViewModel saveViewModel)
        {
            ResultadoLaboratorio resultado = new();
            resultado.IdCita = saveViewModel.IdCita;
            resultado.IdPruebaL = saveViewModel.IdPruebaL;
            resultado.Estado = saveViewModel.Estado;
            resultado.IdPaciente = saveViewModel.IdPaciente;
            resultado = await _resultadoRepository.AddAsync(resultado);

            ResultadoLaboratorioSaveViewModel resultadoSaveViewModel = new();
            resultadoSaveViewModel.Id = resultado.Id;
            resultadoSaveViewModel.IdCita = resultado.IdCita;
            resultadoSaveViewModel.IdPruebaL = resultado.IdPruebaL;
            resultadoSaveViewModel.Estado = resultado.Estado;
            resultadoSaveViewModel.IdPaciente = resultado.IdPaciente;
            return resultadoSaveViewModel;
        }

        public async Task DeleteAsync(int id)
        {
            var resultado = await _resultadoRepository.GetByIdAsync(id);
            await _resultadoRepository.DeleteAsync(resultado);
        }
        public async Task<ICollection<ResultadoLaboratorioViewModel>> GetAllCita(int id)
        {
            var resultado = await _resultadoRepository.GetAllAsyncInclude(new List<string> { "pruebaLaboratorio", "Cita", "paciente" });

            return resultado.Where(r=>r.IdPaciente == id).Select(r => new ResultadoLaboratorioViewModel
            {
                Id = r.Id,
                IdCitaP = r.IdCita,
                IdPruebaL = r.IdPruebaL,
                IdPaciente = r.IdPaciente,
                Estado = r.Estado,
                NombrePruebaLaboratorio = r.pruebaLaboratorio.Nombre,
                NombrePaciente = r.paciente.Nombre + "" + r.paciente.Apellido,
                MotivoCita = r.Cita.MotivoCita
            }).ToList();
        }
        public async Task<ICollection<ResultadoLaboratorioViewModel>> GetAllAsync()
        {
            var resultado = await _resultadoRepository.GetAllAsyncInclude(new List<string> { "pruebaLaboratorio", "Cita", "paciente"});

            return resultado.Select(r => new ResultadoLaboratorioViewModel
            {
                Id = r.Id,
                IdCitaP = r.IdCita,
                IdPruebaL = r.IdPruebaL,
                IdPaciente = r.IdPaciente,
                Estado = r.Estado,
                NombrePruebaLaboratorio = r.pruebaLaboratorio.Nombre,
                NombrePaciente = r.paciente.Nombre + "" + r.paciente.Apellido,
                MotivoCita = r.Cita.MotivoCita
            }).ToList();
        }

        public async Task<ResultadoLaboratorioSaveViewModel> GetByIdAsync(int id)
        {
            var resultado = await _resultadoRepository.GetByIdAsync(id);
            ResultadoLaboratorioSaveViewModel resultadoSaveViewModel = new();
            resultadoSaveViewModel.Id = resultado.Id;
            resultadoSaveViewModel.IdCita = resultado.IdCita;
            resultadoSaveViewModel.IdPruebaL = resultado.IdPruebaL;
            resultadoSaveViewModel.IdPaciente = resultado.IdPaciente;
            resultadoSaveViewModel.Estado = resultado.Estado;
            return resultadoSaveViewModel;
        }

        public async Task UpdateAsync(ResultadoLaboratorioSaveViewModel saveViewModel)
        {
            ResultadoLaboratorio resultado = await _resultadoRepository.GetByIdAsync(saveViewModel.Id);
            resultado.Id = saveViewModel.Id;
            resultado.IdPruebaL = saveViewModel.IdPruebaL;
            resultado.IdCita = saveViewModel.IdCita;
            resultado.IdPaciente = saveViewModel.IdPaciente;
            resultado.Estado = saveViewModel.Estado;

            await _resultadoRepository.UpdateAsync(resultado);
        }
    }
}
