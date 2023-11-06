using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SistemaPacientes.Core.Application.Interfaces.Services;
using SistemaPacientes.Core.Application.ViewModels.User;
using SistemaPacientes.Core.Application.Helpers;
using SistemaPacientes.WebApp.Middlewares;
using SistemaPacientes.Core.Application.ViewModels.PruebaLaboratorio;
using SistemaPacientes.Core.Application.Services;

namespace SistemaPacientes.WebApp.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioServices _usuarioServices;
        private readonly IRoleServices _roleServices;
        private readonly ValidateSession _validateSession;
        public UsuarioController(IUsuarioServices usuarioServices, IRoleServices roleServices, ValidateSession validateSession)
        {
            _usuarioServices = usuarioServices;
            _roleServices = roleServices; 
            _validateSession = validateSession; 
        }
        public async Task<IActionResult> GetAll()
        {
            if (!_validateSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            return View(await _usuarioServices.GetAllAsync());
        }
        public IActionResult Index()
        {
            if (_validateSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel vm)
        {
            if (_validateSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Medico", action = "Index" });
            }
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            UserViewModel userViewModel = await _usuarioServices.Login(vm);
            if (userViewModel != null)
            {
                HttpContext.Session.Set<UserViewModel>("user", userViewModel);
                return RedirectToRoute(new { controller = "Medico", action = "Index" });
            }
            else
            {
                ModelState.AddModelError("", "Usuario o contraseña incorrecta");
            }

            return View(vm);
        }
        public async Task<IActionResult> Register()
        {
            if (!_validateSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Index" });
            }
            UserSaveViewModel vm =new();
            vm.Roles = await _roleServices.GetAllAsync();
            return View("Register",vm);
        }
        public IActionResult Logout()
        {
            if (!_validateSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Index" });
            }
            HttpContext.Session.Remove("user");
            return RedirectToRoute(new { controller = "Usuario", action = "Index" });
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserSaveViewModel userView)
        {
            if (!_validateSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Index" });
            }
            if (!ModelState.IsValid)
            {
                userView.Roles = await _roleServices.GetAllAsync();
                return View("Register", userView);
            }
            userView.Password = PasswordEncryption.EncryptionPass(userView.Password);
            await _usuarioServices.AddAsync(userView);
            return RedirectToRoute(new { controller = "Usuario", action = "GetAll" });
        }
        public async Task<IActionResult> Edit(int id)
        {
            if (!_validateSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Index" });
            }
            UserSaveViewModel vm = await _usuarioServices.GetByIdAsync(id);
            vm.Roles = await _roleServices.GetAllAsync();
            return View("Register", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UserSaveViewModel vm)
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
                vm.Roles = await _roleServices.GetAllAsync();
                return View("Register", vm);
            }
            vm.Password = PasswordEncryption.EncryptionPass(vm.Password);
            await _usuarioServices.UpdateAsync(vm);
            return RedirectToRoute(new { controller = "Usuario", action = "GetAll" });

        }
        public async Task<IActionResult> Delete(int id)
        {
            if (_validateSession.HasAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            if (!_validateSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "GetAll" });
            }

            return View(await _usuarioServices.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (_validateSession.HasAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            if (!_validateSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "GetAll" });
            }
            await _usuarioServices.DeleteAsync(id);
            return RedirectToRoute(new { controller = "Usuario", action = "GetAll" });
        }
    }
}
