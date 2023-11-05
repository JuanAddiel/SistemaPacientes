using Microsoft.AspNetCore.Mvc;
using SistemaPacientes.Core.Application.Interfaces.Services;
using SistemaPacientes.Core.Application.Services;
using SistemaPacientes.Core.Application.ViewModels.Paciente;
using SistemaPacientes.WebApp.Middlewares;

namespace SistemaPacientes.WebApp.Controllers
{
    public class PacienteController : Controller
    {
        private readonly IPacienteServices _pacienteServices;
        private readonly ValidateSession _validateSession;
        public PacienteController(IPacienteServices pacienteServices, ValidateSession validateSession)
        {
            _pacienteServices = pacienteServices;
            _validateSession = validateSession;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _pacienteServices.GetAllAsync());
        }
        public async Task<IActionResult> Create()
        {
            if (!_validateSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Index" });
            }
            PacienteSaveViewModel vm = new();
            return View("SavePaciente", vm);
            
        }
        [HttpPost]
        public async Task<IActionResult> Create(PacienteSaveViewModel vm)
        {
            if (!_validateSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Index" });
            }
            if (!ModelState.IsValid)
            {
                return View("SavePaciente", vm);
            }
            PacienteSaveViewModel Pacientevm = await _pacienteServices.AddAsync(vm);
            if(Pacientevm.Id != 0 && Pacientevm != null)
            {
                Pacientevm.FotoUrl = UploadImg(vm.Foto, Pacientevm.Id);
            }
            await _pacienteServices.UpdateAsync(Pacientevm);
            return RedirectToRoute(new { controller = "Paciente", action = "Index" });

        }
        public async Task<IActionResult> Edit (int id)
        {
            if (!_validateSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Index" });
            }
            PacienteSaveViewModel vm = await _pacienteServices.GetByIdAsync(id);
            return View("SavePaciente", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit (PacienteSaveViewModel vm)
        {
            if (!_validateSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Index" });
            }
            if (!ModelState.IsValid)
            {
                return View("SavePaciente", vm);
            }
            await _pacienteServices.UpdateAsync(vm);
            return RedirectToRoute(new { controller = "Paciente", action = "Index" });
        }
        public async Task<IActionResult> Delete (int id)
        {
            if (!_validateSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Index" });
            }

            return View(await _pacienteServices.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (!_validateSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Index" });
            }
            await _pacienteServices.DeleteAsync(id);
            return RedirectToRoute(new { controller = "Paciente", action = "Index" });
        }

        private string UploadImg(IFormFile file, int id)
        {
            //Obtenemos el path de la carpeta
            string basePath = $"/Images/Pacientes/{id}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");
            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            //Obtenemos el path del file
            Guid guid = Guid.NewGuid();
            FileInfo fileInfo = new FileInfo(file.FileName);
            string filename = fileInfo.Name + fileInfo.Extension;
            string filenameWithPath = Path.Combine(path, filename);
            using(var stream = new FileStream(filenameWithPath, FileMode.Create))
            {
                file.CopyToAsync(stream);
            }
            return Path.Combine(basePath, filename);
        }
    }
}
