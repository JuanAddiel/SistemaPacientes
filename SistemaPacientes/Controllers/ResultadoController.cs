using Microsoft.AspNetCore.Mvc;
using SistemaPacientes.Core.Application.Interfaces.Services;
using SistemaPacientes.Core.Application.Services;
using SistemaPacientes.Core.Application.ViewModels.Cita;
using SistemaPacientes.Core.Application.ViewModels.Paciente;
using SistemaPacientes.Core.Application.ViewModels.PruebaLaboratorio;
using SistemaPacientes.Core.Application.ViewModels.ResultadoLaboratorio;
using SistemaPacientes.WebApp.Middlewares;

namespace SistemaPacientes.WebApp.Controllers
{
    public class ResultadoController : Controller
    {
        private readonly ValidateSession _validateSession;
        private readonly IResultadoServices _resultadoLaboratorio;
        private readonly ICitaServices _citaServices;
        private readonly IPruebaServices _pruebaServices;
        public ResultadoController(ValidateSession validateSession, IResultadoServices resultadoServices, ICitaServices citaServices, IPruebaServices pruebaServices)
        {
            _resultadoLaboratorio = resultadoServices;
            _validateSession = validateSession;
            _citaServices = citaServices;
            _pruebaServices = pruebaServices;
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
            return View(await _resultadoLaboratorio.GetAllAsync());
        }

        public async Task<IActionResult> GetCitasP(int id)
        {
            if (!_validateSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Index" });
            }
            if (_validateSession.HasAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            return View(await _resultadoLaboratorio.GetAllCita(id));
        }
        public async Task<IActionResult> Create(int id)
        {
            if (!_validateSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Index" });
            }
            if (_validateSession.HasAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            if (!_validateSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Index" });
            }
            ResultadoLaboratorioSaveViewModel vm = new();
            vm.pruebaLaboratorio = await _pruebaServices.GetAllAsync();
            vm.cita = await _citaServices.GetByIdAsync(id);
            vm.IdCita = vm.cita.Id;
            vm.IdPaciente = vm.cita.IdPaciente;
            return View("SaveResultado", vm);

        }
        [HttpPost]
        public async Task<IActionResult> Create(ResultadoLaboratorioSaveViewModel vm)
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
                vm.pruebaLaboratorio = await _pruebaServices.GetAllAsync();
                return View("SaveResultado", vm);
            }
            var resultado = await _resultadoLaboratorio.AddAsync(vm);
            if (resultado != null)
            {
                CitaSaveViewModel citavm = await _citaServices.GetByIdAsync(vm.IdCita);
                citavm.Estado = true;
                await _citaServices.UpdateAsync(citavm);
            }

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
            ResultadoLaboratorioSaveViewModel vm = await _resultadoLaboratorio.GetByIdAsync(id);
            return View("SaveResultado", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ResultadoLaboratorioSaveViewModel vm)
        {
            if (!_validateSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Index" });
            }
            if (_validateSession.HasAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            await _resultadoLaboratorio.UpdateAsync(vm);
            return RedirectToRoute(new { controller = "Prueba", action = "Index" });

        }
    }
}
