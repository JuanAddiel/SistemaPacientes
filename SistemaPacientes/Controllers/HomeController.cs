using Microsoft.AspNetCore.Mvc;
using SistemaPacientes.Models;
using SistemaPacientes.WebApp.Middlewares;
using System.Diagnostics;

namespace SistemaPacientes.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ValidateSession _validateSession;
        public HomeController(ILogger<HomeController> logger, ValidateSession validateSession)
        {
            _logger = logger;
            _validateSession = validateSession;
        }

        public IActionResult Index()
        {
            if(_validateSession.HasAdmin())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            if (!_validateSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuario", action = "Index" });
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}