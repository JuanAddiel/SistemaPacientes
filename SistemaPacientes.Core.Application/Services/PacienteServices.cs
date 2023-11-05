using SistemaPacientes.Core.Application.Interfaces.Repositories;
using SistemaPacientes.Core.Application.Interfaces.Services;
using SistemaPacientes.Core.Application.ViewModels.Paciente;
using SistemaPacientes.Core.Domain.Entities;
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

        public async Task<PacienteSaveViewModel> AddAsync(PacienteSaveViewModel saveViewModel)
        {
            Paciente paciente = new();
            paciente.Id = saveViewModel.Id;
            paciente.Nombre = saveViewModel.Nombre;
            paciente.Apellido = saveViewModel.Apellido;
            paciente.Direccion = saveViewModel.Direccion;
            paciente.Telefono = saveViewModel.Telefono;
            paciente.Cedula = saveViewModel.Cedula;
            paciente.Foto = saveViewModel.FotoUrl;
            paciente.Alergias = saveViewModel.Alergias;
            paciente.Fuma = saveViewModel.Fuma;
            paciente.FechaNacimiento = saveViewModel.FechaNacimiento;
            
            paciente = await _pacienteRepository.AddAsync(paciente);

            PacienteSaveViewModel pacienteVm = new();
            pacienteVm.Id = paciente.Id;
            pacienteVm.Nombre = paciente.Nombre;
            pacienteVm.Apellido = paciente.Apellido;
            pacienteVm.Direccion = paciente.Direccion;
            pacienteVm.Telefono = paciente.Telefono;
            pacienteVm.Cedula = paciente.Cedula;
            pacienteVm.FotoUrl = paciente.Foto;
            pacienteVm.Alergias = paciente.Alergias;
            pacienteVm.Fuma = paciente.Fuma;
            pacienteVm.FechaNacimiento = paciente.FechaNacimiento;

            return pacienteVm;

        }

        public async Task DeleteAsync(int id)
        {
            var paciente = await _pacienteRepository.GetByIdAsync(id);
            await _pacienteRepository.DeleteAsync(paciente);
        }

        public async Task<ICollection<PacienteViewModel>> GetAllAsync()
        {
            var pacientes = await _pacienteRepository.GetAllAsyncInclude(new List<string> { "Citas", "ResultadoLaboratorios" });
            return pacientes.Select(paciente => new PacienteViewModel
            {
                Id = paciente.Id,
                Nombre = paciente.Nombre,
                Apellido = paciente.Apellido,
                Direccion = paciente.Direccion,
                Telefono = paciente.Telefono,
                Cedula = paciente.Cedula,
                Foto = paciente.Foto,
                Alergias = paciente.Alergias,
                Fuma = paciente.Fuma,
                FechaNacimiento = paciente.FechaNacimiento,


            }).ToList();
        }

        public async Task<PacienteSaveViewModel> GetByIdAsync(int id)
        {
            var paciente = await _pacienteRepository.GetByIdAsync(id);
            PacienteSaveViewModel pacienteVm = new();
            pacienteVm.Id = paciente.Id;
            pacienteVm.Nombre = paciente.Nombre;
            pacienteVm.Apellido = paciente.Apellido;
            pacienteVm.Direccion = paciente.Direccion;
            pacienteVm.Telefono = paciente.Telefono;
            pacienteVm.Cedula = paciente.Cedula;
            pacienteVm.FotoUrl = paciente.Foto;
            pacienteVm.Alergias = paciente.Alergias;
            pacienteVm.Fuma = paciente.Fuma;
            pacienteVm.FechaNacimiento = paciente.FechaNacimiento;
            return pacienteVm;
        }

        public async Task UpdateAsync(PacienteSaveViewModel saveViewModel)
        {
            Paciente paciente = await _pacienteRepository.GetByIdAsync(saveViewModel.Id);  
            paciente.Id = saveViewModel.Id;
            paciente.Nombre = saveViewModel.Nombre;
            paciente.Apellido = saveViewModel.Apellido;
            paciente.Direccion = saveViewModel.Direccion;
            paciente.Telefono = saveViewModel.Telefono;
            paciente.Cedula = saveViewModel.Cedula;
            paciente.Foto = saveViewModel.FotoUrl;
            paciente.Alergias = saveViewModel.Alergias;
            paciente.Fuma = saveViewModel.Fuma;
            paciente.FechaNacimiento = saveViewModel.FechaNacimiento;
            await _pacienteRepository.UpdateAsync(paciente);
        }
    }
}
