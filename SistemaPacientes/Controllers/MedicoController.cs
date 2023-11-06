using Microsoft.AspNetCore.Mvc;
using SistemaPacientes.Core.Application.Interfaces.Services;
using SistemaPacientes.Core.Application.ViewModels.Medico;
using SistemaPacientes.WebApp.Middlewares;

namespace SistemaPacientes.WebApp.Controllers
{
    public class MedicoController : Controller
    {
        private readonly IMedicoServices _medicoServices;
        private readonly ValidateSession _validateSession;
        public MedicoController(IMedicoServices medicoServices, ValidateSession validateSession)
        {
            _medicoServices = medicoServices;
            _validateSession = validateSession;
        }

        public async Task<IActionResult> Index()
        {
            if (!_validateSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Index" });
            }
            if(!_validateSession.HasAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            return View(await _medicoServices.GetAllAsync());
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
            MedicoSaveViewModel vm = new();
            return View("SaveMedico", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Create(MedicoSaveViewModel vm)
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
                return View("SaveMedico",vm);
            }
            MedicoSaveViewModel medicoSave = await _medicoServices.AddAsync(vm);
            if(medicoSave.Id != 0 && medicoSave != null)
            {
                medicoSave.Foto = UploadFile(vm.File, medicoSave.Id);
            }
            await _medicoServices.UpdateAsync(medicoSave);
            return RedirectToRoute(new { controller = "Medico", action = "Index" });
        }
        public async Task<IActionResult> Edit(int id)
        {
            if (!_validateSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Index" });
            }
            if (!_validateSession.HasAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            MedicoSaveViewModel vm = await _medicoServices.GetByIdAsync(id);
            return View("SaveMedico", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(MedicoSaveViewModel vm)
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
                return View("SaveMedico", vm);
            }
            MedicoSaveViewModel viewModel = await _medicoServices.GetByIdAsync(vm.Id);
            viewModel.File = vm.File;
            viewModel.Foto = UploadFile(viewModel.File, viewModel.Id, true, viewModel.Foto);
            await _medicoServices.UpdateAsync(viewModel);
            return RedirectToRoute(new { controller = "Medico", action = "Index" });

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
            return View("Delete", await _medicoServices.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost (int id)
        {
            if (!_validateSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Index" });
            }
            if (!_validateSession.HasAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            await _medicoServices.DeleteAsync(id);
            return RedirectToRoute(new { controller = "Medico", action = "Index" });
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
            string basePath = $"/Images/Medicos/{id}";
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
