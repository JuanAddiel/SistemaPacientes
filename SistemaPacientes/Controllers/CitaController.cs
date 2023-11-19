using Microsoft.AspNetCore.Mvc;
using SistemaPacientes.Core.Application.Interfaces.Services;
using SistemaPacientes.Core.Application.ViewModels.Cita;
using SistemaPacientes.Core.Application.ViewModels.PruebaLaboratorio;
using SistemaPacientes.WebApp.Middlewares;

namespace SistemaPacientes.WebApp.Controllers
{
    public class CitaController : Controller
    {
        private readonly ICitaServices _citaServices;
        private readonly IPacienteServices _pacienteServices;
        private readonly IMedicoServices _medicoServices;
        private readonly ValidateSession _validateSession;
        public CitaController(ICitaServices citaServices, ValidateSession validateSession, IPacienteServices pacienteServices, IMedicoServices medicoServices)
        {
            _citaServices = citaServices;
            _validateSession = validateSession;
            _pacienteServices = pacienteServices;
            _medicoServices = medicoServices;
        }

        public async Task<IActionResult> Index()
        {
            if (!_validateSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Index" });
            }
            if (_validateSession.HasAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            return View(await _citaServices.GetAllAsync());
        }
        public async Task<IActionResult> Create()
        {
            if (!_validateSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Index" });
            }
            if (_validateSession.HasAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            CitaSaveViewModel vm = new();
            vm.pacientes = await _pacienteServices.GetAllAsync();
            vm.medicos = await _medicoServices.GetAllAsync();
            return View("SaveCita", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CitaSaveViewModel vm)
        {
            vm.Estado = false;
            if (!_validateSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Index" });
            }
            if (_validateSession.HasAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            if (!ModelState.IsValid)
            {
                vm.pacientes = await _pacienteServices.GetAllAsync();
                vm.medicos = await _medicoServices.GetAllAsync();
                return View("SaveCita", vm);
            }
            await _citaServices.AddAsync(vm);
            return RedirectToRoute(new { controller = "Cita", action = "Index" });
        }
        public async Task<IActionResult> Edit(int id)
        {
            if (!_validateSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Index" });
            }
            if (_validateSession.HasAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            CitaSaveViewModel vm = await _citaServices.GetByIdAsync(id);
            vm.pacientes = await _pacienteServices.GetAllAsync();
            vm.medicos = await _medicoServices.GetAllAsync();
            return View("SaveCita", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CitaSaveViewModel vm)
        {
            if (!_validateSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Index" });
            }
            if (_validateSession.HasAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            if (!ModelState.IsValid)
            {
                vm.pacientes = await _pacienteServices.GetAllAsync();
                vm.medicos = await _medicoServices.GetAllAsync();
                return View("SaveCita", vm);
            }
            await _citaServices.UpdateAsync(vm);
            return RedirectToRoute(new { controller = "Cita", action = "Index" });

        }
        public async Task<IActionResult> Delete(int id)
        {
            if (!_validateSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Index" });
            }
            if (_validateSession.HasAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            return View("Delete", await _citaServices.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (!_validateSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Index" });
            }
            if (_validateSession.HasAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            await _citaServices.DeleteAsync(id);
            return RedirectToRoute(new { controller = "Cita", action = "Index" });
        }
    }
}
