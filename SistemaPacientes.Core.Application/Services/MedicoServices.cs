using SistemaPacientes.Core.Application.Interfaces.Repositories;
using SistemaPacientes.Core.Application.Interfaces.Services;
using SistemaPacientes.Core.Application.ViewModels.Medico;
using SistemaPacientes.Core.Domain.Entities;
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
        public async Task<MedicoSaveViewModel> AddAsync(MedicoSaveViewModel saveViewModel)
        {
            Medico medico = new();
            medico.Id = saveViewModel.Id;
            medico.Nombre = saveViewModel.Nombre;
            medico.Apellido = saveViewModel.Apellido;
            medico.Correo = saveViewModel.Correo;
            medico.Telefono = saveViewModel.Telefono;
            medico.Cedula = saveViewModel.Cedula;
            medico.Foto = saveViewModel.Foto;

            medico = await _medicoRepository.AddAsync(medico);

            MedicoSaveViewModel vm = new();
            vm.Id = medico.Id;
            vm.Nombre = medico.Nombre;
            vm.Apellido= medico.Apellido;
            vm.Correo = medico.Correo;
            vm.Telefono= medico.Telefono;
            vm.Cedula= medico.Cedula;
            vm.Foto = medico.Foto;

            return vm;


        }

        public async Task DeleteAsync(int id)
        {
            var medico = await _medicoRepository.GetByIdAsync(id);
            await _medicoRepository.DeleteAsync(medico);
        }

        public async Task<ICollection<MedicoViewModel>> GetAllAsync()
        {
            var medicos = await _medicoRepository.GetAllAsyncInclude(new List<string> { "citas"});
            return medicos.Select(m => new MedicoViewModel
            {
                Id = m.Id,
                Nombre = m.Nombre,
                Apellido = m.Apellido,
                Correo = m.Correo,
                Telefono= m.Telefono,
                Cedula= m.Cedula,
                Foto = m.Foto,

            }).ToList();
        }

        public async Task<MedicoSaveViewModel> GetByIdAsync(int id)
        {
            var medico = await _medicoRepository.GetByIdAsync(id);
            MedicoSaveViewModel vm = new();
            vm.Id = medico.Id;
            vm.Nombre = medico.Nombre;
            vm.Apellido = medico.Apellido;
            vm.Correo = medico.Correo;
            vm.Telefono = medico.Telefono;
            vm.Cedula = medico.Cedula;
            vm.Foto = medico.Foto;

            return vm;

        }

        public async Task UpdateAsync(MedicoSaveViewModel saveViewModel)
        {
            Medico medico = await _medicoRepository.GetByIdAsync(saveViewModel.Id);
            medico.Id = saveViewModel.Id;
            medico.Nombre = saveViewModel.Nombre;
            medico.Apellido = saveViewModel.Apellido;
            medico.Correo = saveViewModel.Correo;
            medico.Telefono = saveViewModel.Telefono;
            medico.Cedula = saveViewModel.Cedula;
            medico.Foto = saveViewModel.Foto;

            await _medicoRepository.UpdateAsync(medico);
        }
    }
}
