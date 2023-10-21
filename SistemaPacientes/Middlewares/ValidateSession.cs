using SistemaPacientes.Core.Application.ViewModels.User;
using SistemaPacientes.Core.Application.Helpers;
namespace SistemaPacientes.WebApp.Middlewares
{
    public class ValidateSession
    {
        private readonly IHttpContextAccessor _httpContext;
        public ValidateSession(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }
        public bool HasUser()
        {
            UserViewModel user = _httpContext.HttpContext.Session.Get<UserViewModel>("user");
            if(user == null)
            {
                return false;
            }

            return true;
        }
    }
}
