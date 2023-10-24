using Microsoft.AspNetCore.Mvc;
using SistemaPacientes.Core.Application.Interfaces.Services;
using SistemaPacientes.Core.Application.ViewModels.Medico;

namespace SistemaPacientes.WebApp.Controllers
{
    public class MedicoController : Controller
    {
        private readonly IMedicoServices _medicoServices;
        public MedicoController(IMedicoServices medicoServices)
        {
            _medicoServices = medicoServices;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Create()
        {
            MedicoSaveViewModel vm = new();
            return View("SaveMedico", vm);
        }
    }
}
