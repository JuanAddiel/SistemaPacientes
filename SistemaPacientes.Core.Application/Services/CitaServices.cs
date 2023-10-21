using SistemaPacientes.Core.Application.Interfaces.Repositories;
using SistemaPacientes.Core.Application.Interfaces.Services;
using SistemaPacientes.Core.Application.ViewModels.Cita;
using SistemaPacientes.Core.Domain.Entities;
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
        public async Task<CitaSaveViewModel> AddAsync(CitaSaveViewModel saveViewModel)
        {
            Cita cita = new Cita();
            cita.Id = saveViewModel.Id;
            cita.IdMedico = saveViewModel.IdMedico;
            cita.IdPaciente = saveViewModel.IdPaciente;
            cita.Estado = saveViewModel.Estado;
            cita.MotivoCita = saveViewModel.MotivoCita;
            cita.FechaCita = saveViewModel.FechaCita;
            cita.HoraCita = saveViewModel.HoraCita;

            cita = await _citaRepository.AddAsync(cita);

            CitaSaveViewModel citaVm = new();
            citaVm.Id = cita.Id;
            citaVm.IdMedico = cita.IdMedico;
            citaVm.IdPaciente = cita.IdPaciente;
            citaVm.Estado = cita.Estado;
            citaVm.MotivoCita = cita.MotivoCita;
            citaVm.FechaCita = cita.FechaCita;
            citaVm.HoraCita = cita.HoraCita;

            return citaVm;


        }

        public async Task DeleteAsync(int id)
        {
            var cita = await _citaRepository.GetByIdAsync(id);
            await _citaRepository.DeleteAsync(cita);
        }

        public async Task<ICollection<CitaViewModel>> GetAllAsync()
        {
            var citas = await _citaRepository.GetAllAsyncInclude(new List<string> { "Medico","Paciente"});
            return citas.Select(cita => new CitaViewModel
            {
                Id = cita.Id,
                IdMedico = cita.IdMedico,
                IdPaciente = cita.IdPaciente,
                Estado = cita.Estado,
                MotivoCita = cita.MotivoCita,
                FechaCita = cita.FechaCita,
                HoraCita = cita.HoraCita,
                NombreMedico = cita.Medico.Nombre,
                NombrePaciente = cita.Paciente.Nombre

            }).ToList();
        }

        public async Task<CitaSaveViewModel> GetByIdAsync(int id)
        {
            var cita = await _citaRepository.GetByIdAsync(id);
            CitaSaveViewModel citaVm = new();
            citaVm.Id = cita.Id;
            citaVm.IdMedico = cita.IdMedico;
            citaVm.IdPaciente = cita.IdPaciente;
            citaVm.Estado = cita.Estado;
            citaVm.MotivoCita = cita.MotivoCita;
            citaVm.FechaCita = cita.FechaCita;
            citaVm.HoraCita = cita.HoraCita;
            return citaVm;

        }

        public async Task UpdateAsync(CitaSaveViewModel saveViewModel)
        {
            Cita cita = await _citaRepository.GetByIdAsync(saveViewModel.Id);
            cita.Id = saveViewModel.Id;
            cita.IdMedico = saveViewModel.IdMedico;
            cita.IdPaciente = saveViewModel.IdPaciente;
            cita.Estado = saveViewModel.Estado;
            cita.MotivoCita = saveViewModel.MotivoCita;
            cita.FechaCita = saveViewModel.FechaCita;
            cita.HoraCita = saveViewModel.HoraCita;
            await _citaRepository.UpdateAsync(cita);
        }
    }
}
