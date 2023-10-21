using SistemaPacientes.Core.Application.Interfaces.Repositories;
using SistemaPacientes.Core.Application.Interfaces.Services;
using SistemaPacientes.Core.Application.ViewModels.PruebaLaboratorio;
using SistemaPacientes.Core.Domain.Entities;
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

        public async Task<PruebaLaboratorioSaveViewModel> AddAsync(PruebaLaboratorioSaveViewModel saveViewModel)
        {
            PruebaLaboratorio prueba = new();
            prueba.Id = saveViewModel.Id;
            prueba.Nombre = saveViewModel.Nombre;
            prueba = await _pruebaRepository.AddAsync(prueba);

            PruebaLaboratorioSaveViewModel pruebaSaveViewModel = new();
            pruebaSaveViewModel.Id = prueba.Id;
            pruebaSaveViewModel.Nombre = prueba.Nombre;
            return pruebaSaveViewModel;

        }

        public async Task DeleteAsync(int id)
        {
            var prueba = await _pruebaRepository.GetByIdAsync(id);    
            await _pruebaRepository.DeleteAsync(prueba);
        }

        public async Task<ICollection<PruebaLaboratorioViewModel>> GetAllAsync()
        {
            var prueba = await _pruebaRepository.GetAllAsyncInclude(new List<string> { "ResultadoLaboratorio" });
            return prueba.Select(p => new PruebaLaboratorioViewModel
            {
                Id = p.Id,
                Nombre = p.Nombre,
            }).ToList();
        }

        public async Task<PruebaLaboratorioSaveViewModel> GetByIdAsync(int id)
        {
            var prueba = await _pruebaRepository.GetByIdAsync(id);
            PruebaLaboratorioSaveViewModel pruebaSaveViewModel = new();
            pruebaSaveViewModel.Id = prueba.Id;
            pruebaSaveViewModel.Nombre = prueba.Nombre;
            return pruebaSaveViewModel;
        }

        public async Task UpdateAsync(PruebaLaboratorioSaveViewModel saveViewModel)
        {
            PruebaLaboratorio prueba = await _pruebaRepository.GetByIdAsync(saveViewModel.Id);
            prueba.Id = saveViewModel.Id;
            prueba.Nombre = saveViewModel.Nombre;
            await _pruebaRepository.UpdateAsync(prueba);
        }
    }
}
