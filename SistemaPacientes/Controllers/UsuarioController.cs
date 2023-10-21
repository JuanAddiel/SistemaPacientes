using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SistemaPacientes.Core.Application.Interfaces.Services;
using SistemaPacientes.Core.Application.ViewModels.User;
using SistemaPacientes.Core.Application.Helpers;

namespace SistemaPacientes.WebApp.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioServices _usuarioServices;
        public UsuarioController(IUsuarioServices usuarioServices) => _usuarioServices = usuarioServices;

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel vm)
        {
            if(!ModelState.IsValid)
            {
                return View(vm);
            }
            UserViewModel userViewModel = await _usuarioServices.Login(vm);
            if (userViewModel != null)
            {
                HttpContext.Session.Set<UserViewModel>("user", userViewModel);
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            else
            {
                ModelState.AddModelError("", "Usuario o contraseña incorrecta");
            }

            return View(vm);
        }
        public IActionResult Register()
        {
            return View(new UserSaveViewModel());
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("user");
            return RedirectToRoute(new { controller = "Usuario", action = "Index" });
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserSaveViewModel userView)
        {
            if(!ModelState.IsValid)
            {
                return View(userView);
            }
            await _usuarioServices.AddAsync(userView);
            return RedirectToRoute(new { controller = "Usuario", action = "Index" });
        }
    }
}
