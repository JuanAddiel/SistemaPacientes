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
            if (!_validateSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Index" });
            }
            if (_validateSession.HasAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            return View(await _pacienteServices.GetAllAsync());
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
            if (_validateSession.HasAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            if (!ModelState.IsValid)
            {
                return View("SavePaciente", vm);
            }
            PacienteSaveViewModel Pacientevm = await _pacienteServices.AddAsync(vm);
            if(Pacientevm.Id != 0 && Pacientevm != null)
            {
                Pacientevm.Foto = UploadFile(vm.File, Pacientevm.Id);
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
            if (_validateSession.HasAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
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
            if (_validateSession.HasAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            if (!ModelState.IsValid)
            {
                return View("SavePaciente", vm);
            }
            PacienteSaveViewModel pacienteVm = await _pacienteServices.GetByIdAsync(vm.Id);
            pacienteVm.File = vm.File;
            pacienteVm.Foto = UploadFile(pacienteVm.File, pacienteVm.Id, true, pacienteVm.Foto);
            await _pacienteServices.UpdateAsync(pacienteVm);
            return RedirectToRoute(new { controller = "Paciente", action = "Index" });
        }
        public async Task<IActionResult> Delete (int id)
        {
            if (!_validateSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Index" });
            }
            if (_validateSession.HasAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
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
            if (_validateSession.HasAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            await _pacienteServices.DeleteAsync(id);
            return RedirectToRoute(new { controller = "Paciente", action = "Index" });
        }

        private string UploadFile(IFormFile file, int id, bool isEditMode = false, string imagePath = "")
        {
            if (isEditMode)
            {
                if (file == null)
                {
                    return imagePath;
                }
            }
            string basePath = $"/Images/Pacientes/{id}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");

            //create folder if not exist
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            //get file extension
            Guid guid = Guid.NewGuid();
            FileInfo fileInfo = new(file.FileName);
            string fileName = guid + fileInfo.Extension;

            string fileNameWithPath = Path.Combine(path, fileName);

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            if (isEditMode)
            {
                string[] oldImagePart = imagePath.Split("/");
                string oldImagePath = oldImagePart[^1];
                string completeImageOldPath = Path.Combine(path, oldImagePath);

                if (System.IO.File.Exists(completeImageOldPath))
                {
                    System.IO.File.Delete(completeImageOldPath);
                }
            }
            return $"{basePath}/{fileName}";
        }
    }
}
