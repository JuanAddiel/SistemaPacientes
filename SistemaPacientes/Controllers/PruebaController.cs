using Microsoft.AspNetCore.Mvc;
using SistemaPacientes.Core.Application.Interfaces.Services;
using SistemaPacientes.Core.Application.ViewModels.Medico;
using SistemaPacientes.Core.Application.ViewModels.PruebaLaboratorio;
using SistemaPacientes.WebApp.Middlewares;

namespace SistemaPacientes.WebApp.Controllers
{
    public class PruebaController : Controller
    {
        private readonly IPruebaServices _pruebaServices;
        private readonly ValidateSession _validateSession;
        public PruebaController(IPruebaServices pruebaServices, ValidateSession validateSession)
        {
            _pruebaServices = pruebaServices;
            _validateSession = validateSession;
        }

        public async Task<IActionResult> Index()
        {
            if (!_validateSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Index" });
            }
            if (!_validateSession.HasAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            return View(await _pruebaServices.GetAllAsync());
        }
        public async Task<IActionResult> Create()
        {
            if (!_validateSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Index" });
            }
            if (!_validateSession.HasAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            PruebaLaboratorioSaveViewModel vm = new();
            return View("SavePrueba", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Create(PruebaLaboratorioSaveViewModel vm)
        {
            if (!_validateSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Index" });
            }
            if (!_validateSession.HasAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            if (!ModelState.IsValid)
            {
                return View("SavePrueba", vm);
            }
            await _pruebaServices.AddAsync(vm);
            return RedirectToRoute(new { controller = "Prueba", action = "Index" });
        }
        public async Task<IActionResult> Edit(int id)
        {
            if (!_validateSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Index" });
            }
            PruebaLaboratorioSaveViewModel vm = await _pruebaServices.GetByIdAsync(id);
            return View("SavePrueba", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(PruebaLaboratorioSaveViewModel vm)
        {
            if (!_validateSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Index" });
            }
            if (!_validateSession.HasAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            if (!ModelState.IsValid)
            {
                return View("SavePrueba", vm);
            }
            await _pruebaServices.UpdateAsync(vm);
            return RedirectToRoute(new { controller = "Prueba", action = "Index" });

        }
        public async Task<IActionResult> Delete(int id)
        {
            if (!_validateSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Index" });
            }
            if (!_validateSession.HasAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            return View("Delete", await _pruebaServices.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (!_validateSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Index" });
            }
            if (!_validateSession.HasAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            await _pruebaServices.DeleteAsync(id);
            return RedirectToRoute(new { controller = "Prueba", action = "Index" });
        }
    }
}
